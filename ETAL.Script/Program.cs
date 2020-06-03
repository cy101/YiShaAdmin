using System;
using System.IO;

namespace ETAL.Script
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            #region 目录文件修改
            string dir = @"D:\Projects\Gitee\MessagerHelper\ETALAdmin";
            foreach (string item in System.IO.Directory.EnumerateDirectories(dir,"*",System.IO.SearchOption.AllDirectories))
            {
                if (item.Contains("YiSha."))
                {
                    if (Directory.GetFiles(item,"*",SearchOption.AllDirectories).Length == 0)
                    {
                        try
                        {
                            Directory.Delete(item);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    //System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(item);
                    //string desFile = item.Replace("YiSha.", "ETAL.");
                    //if (!System.IO.Directory.Exists(Path.GetDirectoryName(desFile)))
                    //{
                    //    System.IO.Directory.CreateDirectory(Path.GetDirectoryName(desFile));
                    //}
                    //try
                    //{
                    //    File.Move(item, desFile);
                    //    File.Delete(item);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine($"移动到:{desFile}异常："+ex.Message);
                    //}
                }
            }
            #endregion
        }
    }
}
