﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Contractor.Interfaces;
using System.Diagnostics;

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

            var saveData = JSONSerializer.JSONToSaveData(json);

            Trace.WriteLine("should run mapper");
            Mapper.SaveDataToAppData(saveData);

        }

        public static void Save()
        {
            Trace.WriteLine("saving");


            string path = Path.Combine(directoryPath, fileName);

            var saveData = Mapper.AppDataToSaveData();

            string json = JSONSerializer.SaveDataToJSON(saveData);

            File.WriteAllText(path, json);


            //Preferences.Set("MaxFreeTime", DataStore.MaxFreeTime);
            //Preferences.Set("MaxProductiveTime", DataStore.MaxProductiveTime);
            //Preferences.Set("Factor", DataStore.Factor);
            //Preferences.Set("ProdSeconds", DataStore.ProdSeconds);
        }

        public static void Clear() => Preferences.Clear();
    }
}
