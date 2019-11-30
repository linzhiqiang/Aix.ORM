using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Aix.EntityGenerator.Utils
{
    public class BuilderUtils
    {
        public static string BuildSpace(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public static void AppendFile(string fileParentDirectoryName, string fileName, string content)
        {
            if (!Directory.Exists(fileParentDirectoryName))
            {
                Directory.CreateDirectory(fileParentDirectoryName);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(fileParentDirectoryName, fileName), true, Encoding.UTF8))
                {
                    sw.Write(content);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("ORMUtils.AppendFile写文件出错：{0}", ex.ToString());
                throw new Exception(errorInfo, ex);
            }
        }

        public static void CreateFile(string fileParentDirectoryName, string fileName, string content)
        {
            if (!Directory.Exists(fileParentDirectoryName))
            {
                Directory.CreateDirectory(fileParentDirectoryName);
            }
            if (File.Exists(Path.Combine(fileParentDirectoryName, fileName)))
            {
                File.Delete(Path.Combine(fileParentDirectoryName, fileName));
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(fileParentDirectoryName, fileName), false, Encoding.UTF8))
                {
                    sw.Write(content);
                    sw.Flush();
                }
            }
            catch (Exception ex)
            {
                string errorInfo = string.Format("ORMUtils.CreateFile写文件出错：{0}", ex.ToString());
                throw new Exception(errorInfo, ex);
            }
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
