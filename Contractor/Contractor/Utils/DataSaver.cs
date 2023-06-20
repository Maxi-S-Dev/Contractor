using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Contractor.Interfaces;
using System.Diagnostics;
using System.ComponentModel;
using Contractor.Services;

namespace Contractor.Utils
{
    public static class DataSaver
    {
        static string directoryPath = FileSystem.Current.AppDataDirectory;
        static string fileName = "AppData.json";

        public static void Load()
        { 
            string path = Path.Combine(directoryPath, fileName);

            //File.Delete(path);

            if (!File.Exists(path))
            {
                File.Create(path);
                return;
            }

            string json = File.ReadAllText(path);

            if (string.IsNullOrEmpty(json)) return;

            var saveData = JSONSerializer.JSONToSaveData(json);

            Trace.WriteLine(path);

            if (saveData.lastDate == DateTime.Today) Mapper.SaveDataToAppData(saveData);
            else if (saveData.lastDate == DateTime.Today.AddDays(-1).Date && Preferences.Get("resetFreeTime", true) == false)
            {
                (Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore).FreeSeconds = saveData.FreeSeconds;
            }
        }

        public static void Save()
        {
            string path = Path.Combine(directoryPath, fileName);

            var saveData = Mapper.AppDataToSaveData();

            string json = JSONSerializer.SaveDataToJSON(saveData);

            File.WriteAllText(path, json);
        }
    }
}
