using Contractor.Services;
using Contractor.ViewModel;
using System.Diagnostics;

namespace Contractor.Utils
{
    public static class DataSaver
    {
        static string directoryPath = FileSystem.Current.AppDataDirectory;
        static string fileName = "AppData.json";

        public static Task Load()
        { 
            string path = Path.Combine(directoryPath, fileName);

            if (!File.Exists(path)) return Task.CompletedTask;

            string json = File.ReadAllText(path);


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
            string path = Path.Combine(directoryPath, fileName);

            var saveData = Mapper.AppDataToSaveData();

            string json = JSONSerializer.SaveDataToJSON(saveData);

            using FileStream outputStream = File.OpenWrite(path);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(json);
        }
    }
}
