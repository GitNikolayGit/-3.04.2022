using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace HomeWorkWpf2
{
    internal class Utils
    {
        // запись в файл в формате json
        public static void WriteJson<T>(string _fileName, List<T> list)
        {
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(_fileName, FileMode.Create))
            {
                jsonFormat.WriteObject(fs, list);
            }
        }

        // чтение из файла формата json
        public static List<T> ReadJson<T>(string fileName)
        {
            List<T> list = new List<T>();
            DataContractJsonSerializer jsonFormat = new DataContractJsonSerializer(typeof(List<T>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                list = jsonFormat.ReadObject(fs) as List<T>;
            }
            return list;
        } 
    }
}
