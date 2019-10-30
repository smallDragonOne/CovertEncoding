using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace encodingCovert
{
    public  class FileEncoding
    {

        public static void StartConvert(string path,bool isFile,string outEncoding,string inEncording)
        {
            ConvertEncoding(path,isFile, outEncoding, inEncording);
            ;
        }

        public static void ConvertEncoding(string sourceFile, bool isFile, string outEncoding,string inEncording, string desFile = "")
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

            var config = Path.Combine(Directory.GetCurrentDirectory(), "config.txt");

            var content = File.ReadAllText(config);

            var fileQuery = from f in fileList.AsParallel()
                            let extension = Path.GetExtension(f)
                            where content.Contains(extension)
                            select f;
            var files = fileQuery.ToList();

            var destFile = string.IsNullOrWhiteSpace(desFile) ? sourceFile : desFile;

            Parallel.ForEach(files, item => {
                var r = new StreamReader(item, GetReplaceUtf8(inEncording), true);
                var readTxt = r.ReadToEnd();
                r.Close();
                File.WriteAllText(item, readTxt, GetReplaceUtf8(outEncoding));
            });
           
            
        }

        private static Encoding GetReplaceUtf8(string encording)
        {
            if (encording == "utf-8")
            {
                return new UTF8Encoding(false);
            }
            else if (encording == "utf-8-bom")
            {
                return Encoding.UTF8;
            }
            else return Encoding.GetEncoding(encording);
        }
    }
}
