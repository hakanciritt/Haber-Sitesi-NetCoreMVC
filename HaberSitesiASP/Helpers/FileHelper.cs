using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace HaberSitesiASP.Helpers
{
    public static class FileHelper
    {
        public static string Save(string path, IFormFile file)
        {
            string fileName;
            using (var stream = System.IO.File.Create(path))
            {

                file.CopyTo(stream);
                stream.Flush();
                fileName = file.FileName;
            }
            return fileName;
        }
        public static List<string> Save(string path, List<IFormFile> files)
        {
            List<string> list = new List<string>();
            using (var stream = System.IO.File.Create(path))
            {
                foreach (var file in files)
                {
                    file.CopyTo(stream);
                    stream.Flush();
                    list.Add(file.FileName);
                }
            }
            return list;
        }

        public static void Delete(string path)
        {
            System.IO.File.Delete(path);
        }
    }
}
