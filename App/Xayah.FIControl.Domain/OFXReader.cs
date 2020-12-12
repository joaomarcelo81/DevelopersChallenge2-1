using System;
using System.IO;
using System.Text;

namespace Xayah.FIControl.Domain
{
    public class OFXReader
    {
        private FileStream fs;

        public FileStream GetFileData()
        {
            return fs;
        }

        public OFXReader(string fileName)
        {
            fs = new FileStream(fileName,
                                          FileMode.Open,
                                          FileAccess.Read);
        }

        public string GetTagData(string tagname)
        {
            string contentTag = string.Empty;

            var Begin = $"<{tagname}>";
            var End = $"</{tagname}>";
            try
            {
                
                using (var reader = new StreamReader(fs, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.IndexOf(Begin) >= 0)
                            contentTag = line.Substring(Begin.Length, line.Length - Begin.Length);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return contentTag;
        }
    }
}
