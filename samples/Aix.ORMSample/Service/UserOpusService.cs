using Aix.ORM.Common;
using Aix.ORMSample.Common.Utils;
using Aix.ORMSample.Entity;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aix.ORMSample.Service
{
    public class UserOpusService
    {
        private ILogger<UserOpusService> _logger;
        private UserOpusRepository _userOpusRepository;
        BlockingCollection<UserOpus> BlockQueue = new BlockingCollection<UserOpus>(new ConcurrentQueue<UserOpus>());
        int Count = 0;
        public UserOpusService(ILogger<UserOpusService> logger, UserOpusRepository userOpusRepository)
        {
            _logger = logger;
            _userOpusRepository = userOpusRepository;
        }

        public Task Load()
        {
            Task.Factory.StartNew(async()=> {
                await LoadData();
            }, TaskCreationOptions.LongRunning);
          

            for (int i = 0; i < 1; i++)
            {
                Task.Factory.StartNew(async () => {
                    await ProcessData();
                }, TaskCreationOptions.LongRunning);
                
            }


            return Task.CompletedTask;
        }
        public async Task LoadData()
        {
            var pageView = new PageView()
            {
                PageIndex = 0,
                PageSize = 50
            };
            while (true)
            {
                if (BlockQueue.Count >= 20000)
                {
                    await Task.Delay(10000);
                    continue;
                }

                var pageData = await _userOpusRepository.PageQuery(pageView);
                if (pageData.DataList.Count == 0)
                {
                    break;
                }



                foreach (var item in pageData.DataList)
                {

                    BlockQueue.Add(item);
                }

                pageView.PageIndex++;
            }
            _logger.LogInformation($"************全部完成****************");

        }


        private async Task ProcessData()
        {
            Stopwatch sw = new Stopwatch();
            while (true)
            {
                var userOpus = BlockQueue.Take();
                if (userOpus != null)
                {
                    try
                    {
                        sw.Start();
                        //await LoadItem(userOpus, userOpus.CoverUrl, "image");
                       var success =  await LoadItem(userOpus, userOpus.VoiceUrl, "video");
                        //更新成功
                        if (success)
                        {
                            await _userOpusRepository.UpdateIsLoad(userOpus.OpusId, 1);
                        }
                       
                        sw.Stop();
                        var currentCount = Interlocked.Increment(ref Count);
                        _logger.LogInformation($"************处理第{currentCount}条，id：{userOpus.OpusId},耗时：{sw.ElapsedMilliseconds/1000.0}秒");
                        sw.Reset();
                    }
                    catch (Exception ex)
                    {
                        userOpus.ErrorCount++;
                        if (userOpus.ErrorCount <= 3)
                        {
                            BlockQueue.Add(userOpus);
                        }
                        _logger.LogError(ex, "出错");
                    }

                }
            }

        }
        private async Task<bool> LoadItem(UserOpus userOpus, string url, string rootDir)
        {
            if (string.IsNullOrEmpty(url)) return false;
           
            var index = url.LastIndexOf("?");
            var fileExt = "";
            if (index >= 0)
            {
                fileExt = Path.GetExtension(url.Substring(0, index));
            }
            else
            {
                fileExt = Path.GetExtension(url);
            }
            var fileName = $"{userOpus.OpusId}{fileExt}";

            string savePath = Path.Combine("F:\\bbybak", rootDir, fileName);
            if (!File.Exists(savePath))
            {
                byte[] data = await MyHttpClient.Instance.GetAsync<byte[]>(url);
               // if (data == null || data.Length == 0) return false;
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    await fs.WriteAsync(data, 0, data.Length);
                }
                return true;
            }
            else
            {
                return true;
            }

        }

    }





}
