using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InM
{
    public class StorageController
    {

        public static void Save(string filename, StorageModel sm)
        {

            string str = JsonConvert.SerializeObject(sm);
            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(str);

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (GZipStream Compress = new GZipStream(fs, CompressionMode.Compress))
                {
                    Compress.Write(bytes, 0, bytes.Length);
                }
            }
        }
        
        public static StorageModel Load(string filename)
        {
            if (!File.Exists(filename)) return null;
            try
            {
                MemoryStream tempMs = new MemoryStream();
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    using (GZipStream Compress = new GZipStream(fs, CompressionMode.Decompress))
                    {
                        Compress.CopyTo(tempMs);
                    }
                }
                byte[] bytes = tempMs.ToArray();
                string str = Encoding.GetEncoding("UTF-8").GetString(bytes);
                return JsonConvert.DeserializeObject<StorageModel>(str);
            }
            catch
            {
                return null;
            }
        }
    }
}
