using Aix.ORM.Common;
using Aix.ORMSample.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Aix.ORMSample.Entity;
using Aix.ORMSample.Common.Utils;
using System.IO;

namespace Aix.ORMSample.Service
{
    public class RelicService
    {
        private ILogger<RelicService> _logger;
        private RelicRepository _relicRepository;

        public RelicService(ILogger<RelicService> logger, RelicRepository relicRepository)
        {
            _logger = logger;
            _relicRepository = relicRepository;

        }

        public async Task TestOrm()
        {
            // var exists = await _relicRepository.ExistsRelicItem(1000000);
            // var inList = await _relicRepository.QueryRelicItemByIds(new List<int>());

            var autoResetEvent = new AutoResetEvent(false);
            int index = 0;
           // while (true)
            {
                 Task.Run(async()=> {
                  var pageView = new PageView()
                  {
                      PageIndex = 0,
                      PageSize = 100
                  };
                  var pageData = await _relicRepository.PageQuery(pageView);
                     autoResetEvent.Set();
                     _logger.LogInformation($"************:{index++}");
                 });

                autoResetEvent.WaitOne();
            }
        }

        public async Task BuildSearchJson()
        {
            var pageView = new PageView()
            {
                PageIndex = 0,
                PageSize = 10000
            };
            var relicData = await _relicRepository.PageQuery(pageView);
            var allRelic = relicData.DataList;

            var tagDict = new Dictionary<string, List<int>>();
            foreach (var item in allRelic)
            {
                var tagList = await _relicRepository.QueryRelicTag(item.Id);
                foreach (var tag in tagList.Take(7))
                {
                    if (string.IsNullOrEmpty(tag.Content)) continue;

                    //if (tag.TagType == 6)
                    //{
                    //    var tokens =await GetToken(tag.Content);
                    //}

                    if (tagDict.ContainsKey(tag.Content))
                    {
                        tagDict[tag.Content].Add(tag.RelicId);
                    }
                    else
                    {
                        tagDict.Add(tag.Content, new List<int> { tag.RelicId });
                    }
                }
            }


            var targetJson = new List<object>();
            foreach (var item in tagDict)
            {
                targetJson.Add(new { 
                tag=item.Key,
                list=item.Value
                });
            }

            string savePath = Path.Combine("F:\\wenbohui\\tag.json");
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
            }

            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(JsonUtils.ToJson(targetJson)); //["tag":]
                }

            }
            _logger.LogInformation($"*****全部完成，共{tagDict.Count}条****");
        }

        public async Task Load()
        {
            var pageView = new PageView()
            {
                PageIndex = 0,
                PageSize = 100
            };
            int Count = 0;
            var allResult = new List<object>();
            while (true)
            {
                var pageData = await _relicRepository.PageQuery(pageView);
                if (pageData.DataList.Count == 0)
                {
                    break;
                }



                foreach (var item in pageData.DataList)
                {
                    var currentCount = Interlocked.Increment(ref Count);
                    _logger.LogInformation($"************开始处理第{currentCount}条,id={item.Id}");
                    //处理

                    var picData = await _relicRepository.QueryRelicItemPics(item.Id);
                    var mediaData = await _relicRepository.QueryRelicItemMedia(item.Id);
                    var tagData = await _relicRepository.QueryRelicTag(item.Id);

                    var imageList = GetOriginalImage(picData);
                    var videoMediaList = mediaData.Where(x => x.MediaType == 1).ToList();
                    var vrMediaList = mediaData.Where(x => x.MediaType == 2 || x.MediaType == 3).ToList();

                    //下载coverurl
                    var showCoverUrlPath = await LoadUrlData("", "cover_" + item.Id.ToString(), item.ShowCoverUrl);

                    //下载内容图片
                    var relicPicsListPath = new List<object>();
                    int index = 1;
                    foreach (var imageUrl in imageList)
                    {
                        var tempPath = await LoadUrlData("", $"pic_{item.Id.ToString()}_{index}", imageUrl);

                        if (!string.IsNullOrEmpty(tempPath))
                        {
                            relicPicsListPath.Add(JsonUtils.ToJson( new ImageDTO { o = tempPath }));
                            index++;
                        }

                    }

                    //下载视频
                    var videoMediaListPath = new List<object>();
                    index = 1;
                    foreach (var videoUrl in videoMediaList)
                    {
                        var tempPath = await LoadUrlData("", $"video_{item.Id.ToString()}_{index}", videoUrl.MediaUrl);

                        if (!string.IsNullOrEmpty(tempPath))
                        {
                            videoMediaListPath.Add(new
                            {
                                id = videoUrl.Id,
                                relicId = videoUrl.RelicId,
                                mediaType = videoUrl.MediaType,
                                coverUrl = "",
                                mediaUrl = tempPath
                            });
                            index++;
                        }
                    }

                    //下载vr
                    var vrMediaListPath = new List<object>();
                    index = 1;
                    foreach (var vrUrl in vrMediaList)
                    {
                        var tempPath = await LoadUrlData("", $"vr_{item.Id.ToString()}_{index}", vrUrl.MediaUrl);

                        if (!string.IsNullOrEmpty(tempPath))
                        {
                            vrMediaListPath.Add(new
                            {
                                id = vrUrl.Id,
                                relicId = vrUrl.RelicId,
                                mediaType = vrUrl.MediaType,
                                coverUrl = "",
                                mediaUrl = tempPath
                            });
                            index++;
                        }

                    }

                    var json = new
                    {
                        id = item.Id,
                        title = item.Title, //标题
                        summary = item.Summary,//摘要
                        content = item.Content,//内容
                        materialName = item.MaterialName,//材质
                        dynastyName = item.DynastyName,//年代
                        usageName = item.UsageName,//功用
                        valueLevelName = item.ValueLevelName,//价值
                        museumName = item.MuseumName,//来源

                        showCoverUrl = showCoverUrlPath,//本地路径

                        relicPicsList = relicPicsListPath, //图片 原图

                        videoMediaList = videoMediaListPath,//视频  {coverUrl,mediaUrl}  原图

                        vrMediaList = vrMediaListPath,//vr模型  {coverUrl,mediaUrl} 原图

                        tagList = ConvertTag(tagData)

                    };

                    allResult.Add(json);

                }

                pageView.PageIndex++;
            }

            var isJson = true;

            if (isJson)
            {
                string savePath = Path.Combine("F:\\wenbohui\\relic.json");
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }

                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(JsonUtils.ToJson(allResult));
                    }

                }
            }
            else
            {
                string savePath = Path.Combine("F:\\wenbohui\\relic.txt");
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }

                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        foreach (var item in allResult)
                        {
                            sw.WriteLine(JsonUtils.ToJson(item));
                        }
                    }

                }

            }
            _logger.LogInformation($"**********************************************");
            _logger.LogInformation($"*****全部完成，共{allResult.Count}条****");
            _logger.LogInformation($"**********************************************");
        }

        private List<string> GetOriginalImage(List<RelicItemPics> list)
        {
            var result = new List<string>();
            foreach (var item in list)
            {
                if (!string.IsNullOrEmpty(item.PicUrls))
                {
                    var temp = JsonUtils.FromJson<ImageDTO>(item.PicUrls);
                    if (temp != null)
                    {
                        result.Add(temp.o);
                    }
                }
            }

            return result;
        }

        private List<object> ConvertTag(List<RelicTag> list)
        {
            List<object> result = new List<object>();
            foreach (var item in list.Take(7))
            {
                var temp = new
                {  
                    relicId=item.RelicId,
                    tagType = item.TagType,
                    content = item.Content,
                    sequence = item.Sequence,
                };
                result.Add(temp);
            }

            return result;
        }
        private List<object> ConvertTagOld(List<RelicTag> list)
        {
            List<object> result = new List<object>();
            foreach (var item in list.Take(7))
            {
                //var temp = item.Content;
                //result.Add(temp);

                if (item.TagType == 6)
                {
                    var temp = new
                    {
                        tagType = item.TagType,
                        content = item.Content,
                        sequence = item.Sequence,
                        tokens = GetToken(item.Content)
                    };


                    //把内容分词，加入列表
                    //foreach (var single in item.Content)
                    //{
                    //    result.Add(single.ToString());
                    //}
                    //http://es.cihi.sdo.com:8080/_analyze
                }
                else
                {
                    var temp = new
                    {
                        tagType = item.TagType,
                        content = item.Content,
                        sequence = item.Sequence,
                    };
                    result.Add(temp);
                }

            }
            return result;
        }

        private async Task<List<string>> GetToken(string tag)
        {
            var result = new List<string>();
            var url = "http://es.cihi.sdo.com:8080/_analyze";

           // var res1 = await MyHttpClient.Instance.DoPostJsonAsync<ESTokenResponse>(url,$"analyzer=ik_max_word&text={tag}");
            //var res1 = await MyHttpClient.Instance.DoPostJsonAsync<ESTokenResponse>(url, new Dictionary<string,string> {
            //    { "analyzer","ik_max_word"},
            //     { "text",tag}
            //});
            var res = await MyHttpClient.Instance.DoPostJsonAsync<ESTokenResponse>(url, new
            {
                analyzer = "ik_max_word",
                text = tag
            });

            if (res != null && res.tokens != null)
            {
                result.AddRange(res.tokens.Select(x => x.token));
            }

            return result;
        }

        private async Task<string> LoadUrlData(string rootDir, string fileId, string url)
        {
            // string url = relicItem.ShowCoverUrl;
            if (string.IsNullOrWhiteSpace(url)) return "";
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
            var fileName = $"{fileId}{fileExt}";
            string savePath = Path.Combine("F:\\wenbohui\\image", rootDir, fileName);
            CreateDirIfNoExists(savePath);


            if (!File.Exists(savePath))
            {
                byte[] data = await MyHttpClient.Instance.GetAsync<byte[]>(url);
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    await fs.WriteAsync(data, 0, data.Length);
                }
            }

            return Path.Combine(rootDir, fileName);
        }
        private void CreateDirIfNoExists(string path)
        {

            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }

    public class ImageDTO
    {
        public string o { get; set; }
        public string l { get; set; }
        public string m { get; set; }
        public string s { get; set; }
    }

    public class ESTokenResponse
    {
        public TokenInfo[] tokens { get; set; }
    }

    public class TokenInfo
    {
        public string token { get; set; }
        public int start_offset { get; set; }
        public int end_offset { get; set; }

        public string type { get; set; }

        public int position { get; set; }


    }
}
