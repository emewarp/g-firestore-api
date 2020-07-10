using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MyFirestoreCrossCutting
{
    public static class ConfigDownloader
    {
        const string PROJECT = "ProjectName";
        public static string GetProjectName()
        {
            string json = DownloadConfig();
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(json).TryGetValue(PROJECT, out string projectName) ? projectName : PROJECT;
            }
            catch(JsonReaderException e)
            {
                throw e;
            }
            

        }
        private static string DownloadConfig()
        {
            try
            {
                return File.ReadAllText(@"..\MyFirestoreCrossCutting\Resources\ViquesConfig.json");              
            }
            catch(FileNotFoundException e)
            {
                throw e;
            }
            
        }
    }
}
