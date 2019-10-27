using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encodingCovert
{
    public  class FileEncoding
    {

        public static void StartConvert(string path,bool isFile)
        {
            ConvertEncoding(path,isFile);
            ;
        }

        public static void ConvertEncoding(string sourceFile, bool isFile, string desFile = "")
        {
            var fileList = new List<string>();
            if (isFile)
            {
                fileList.Add(sourceFile);
            }
            else
            {

                fileList = new List<string>(Directory.GetFiles(sourceFile, "*", SearchOption.AllDirectories));
            }

            var fileQuery = from f in fileList.AsParallel()
                            let extension = Path.GetExtension(f)
                            where extension == ".txt" || extension == ".cshtml"
                            select f;
            var files = fileQuery.ToList();

            var destFile = string.IsNullOrWhiteSpace(desFile) ? sourceFile : desFile;

            Parallel.ForEach(files, item => {
                File.WriteAllText(item, File.ReadAllText(item,Encoding.Unicode), Encoding.GetEncoding("UTF-8"));
            });
           
            
        }
    }
}
