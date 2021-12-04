using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace HomeWorkTheme11.Organization
{
    internal class Serialized
    {
        public static void SerializedJson(string path, Company company)
        {
            string json = JsonConvert.SerializeObject(company);
            File.WriteAllText(path, json);
        }
        public static void SerializedJson(Company company)
        {
            string json = JsonConvert.SerializeObject(company);
            File.WriteAllText($"{ApplicationViewModel.ApplicationViewModel.Path}data.json", json);
        }
        public static Company DeserializedJson(string path)
        {
            string jsonText = File.ReadAllText(path);
            var company = JsonConvert.DeserializeObject<Company>(jsonText);
            return company;
        }
        public static Company DeserializedJson()
        {
            string jsonText = File.ReadAllText($"{ApplicationViewModel.ApplicationViewModel.Path}data.json");
            var company = JsonConvert.DeserializeObject<Company>(jsonText);
            return company;
        }

    }
}
