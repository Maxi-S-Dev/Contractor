using Contractor.Services;
using System.Diagnostics;
using System.IO;

namespace Contractor.Utils
{
    public static class DataSaver
    {
        static string directoryPath = FileSystem.Current.AppDataDirectory;
        static string fileName = "AppData.json";
        static string path = Path.Combine(directoryPath, fileName);

        public static Task Load()
        {

            Trace.WriteLine("Loading");
            if (!File.Exists(path)) return Task.CompletedTask;
            Trace.WriteLine("File Exists");
            StreamReader sr = new StreamReader(path);
            //File.Delete(path);

            string json = sr.ReadToEnd();
            sr.Close();
            Trace.WriteLine($"json string: {json}");

            var saveData = JSONSerializer.JSONToSaveData(json);

            if(saveData is null) return Task.CompletedTask;
            Trace.WriteLine("Save Data is not empty");

            if (saveData.lastDate == DateTime.Today) Mapper.SaveDataToAppData(saveData);

            else if (Preferences.Get("resetFreeTime", true) == false)
            {
                (Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore).FreeSeconds = saveData.FreeSeconds;
            }
            return Task.CompletedTask;
        }

        /*
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
        */

        public static async void Save()
        {
            Trace.WriteLine("saving");
            var saveData = Mapper.AppDataToSaveData();

            string json = JSONSerializer.SaveDataToJSON(saveData);
            Trace.WriteLine($"Saving json: {json}");

            using FileStream outputStream = File.OpenWrite(path);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(json);
            streamWriter.Close();
            Trace.WriteLine("json written");
        }
    }
}
