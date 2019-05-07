using Json2KeyValue;
using System.Collections.Generic;
using System.IO;
using TurtleGame.Models;

namespace TurtleGame.Services
{
    public class GenerateFile
    {
        public static string defaultConfigNameFile = "config";
        public static string defaultActionNameFile = "success";
        private static string path = "../../files/{0}.json";

        public static Config GenerateConfigFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(string.Format(path, fileName.ToLower())))
            {
                string configFileJson = reader.ReadToEnd();
                if (configFileJson.ToLower().Contains("name"))
                    return JsonConvert.DeserializeObject<Config>(configFileJson);

                return GenerateConfigFile(defaultConfigNameFile);

            }
        }

        public static List<string> GenerateActionFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(string.Format(path, fileName.ToLower())))
            {
                string actionFileJson = reader.ReadToEnd();
                if (actionFileJson.ToLower().Contains("rotate"))
                    return JsonConvert.DeserializeObject<List<string>>(actionFileJson);

                return GenerateActionFile(defaultActionNameFile);
            }
        }

        public static bool ValidFileExists(string fileName)
        {
            return File.Exists(string.Format(path, fileName.ToLower()));
        }
    }
}
