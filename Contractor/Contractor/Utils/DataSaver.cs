using Contractor.Services;
using System.Diagnostics;

namespace Contractor.Utils
{
    public static class DataSaver
    {
        static string directoryPath = FileSystem.Current.AppDataDirectory;
        static string fileName = "AppData.json";
        static string path = Path.Combine(directoryPath, fileName);

        public static Task Load()
        {
            if (!File.Exists(path)) return Task.CompletedTask;

            StreamReader sr = new StreamReader(path);

            //File.Delete(path);

            string json = sr.ReadToEnd();

            var saveData = JSONSerializer.JSONToSaveData(json);

            if(saveData is null) return Task.CompletedTask;

            if (saveData.lastDate == DateTime.Today) Mapper.SaveDataToAppData(saveData);

            else if (Preferences.Get("resetFreeTime", true) == false)
            {
                (Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore).FreeSeconds = saveData.FreeSeconds;
            }
            return Task.CompletedTask;
        }

        public static Task Load(bool debug)
        {
            if (!File.Exists(path)) return Task.CompletedTask;

            string json = File.ReadAllText(path);

            if(json.EndsWith("}}")) json = json.Replace("}}", "}");

            if (string.IsNullOrEmpty(json)) return Task.CompletedTask;

            var saveData = JSONSerializer.JSONToSaveData(json);

            if (saveData.lastDate == DateTime.Today) Mapper.SaveDataToAppData(saveData);
            else if (saveData.lastDate == DateTime.Today.AddDays(-1).Date && Preferences.Get("resetFreeTime", true) == false)
            {
                (Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore).FreeSeconds = saveData.FreeSeconds;
            }
            return Task.CompletedTask;
        }

        public static async void Save()
        {
            var saveData = Mapper.AppDataToSaveData();

            string json = JSONSerializer.SaveDataToJSON(saveData);

            using FileStream outputStream = File.OpenWrite(path);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(json);
        }
    }
}
