using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Contractor.Interfaces;

namespace Contractor.Services
{
    public static class DataSaver
    {
        static string directoryPath = FileSystem.Current.AppDataDirectory;
        static string fileName = "AppData.json";

        public static void Load()
        {
            string path = Path.Combine(directoryPath, fileName);
            //DataStore.MaxFreeTime = Preferences.Get("MaxFreeTime", 6);
            //DataStore.MaxProductiveTime = Preferences.Get("MaxProductiveTime", 8);
            ////DataStore.Factor = (float)Preferences.Get("Factor", 1.75);
            //DataStore.ProdSeconds = Preferences.Get("ProdSeconds", 0);

            if (File.Exists(path))
            {
                File.ReadAllText(Path.Combine(directoryPath, fileName));
                return;
            }

            File.Create(path);
        }

        public static void Save()
        {

            //Preferences.Set("MaxFreeTime", DataStore.MaxFreeTime);
            //Preferences.Set("MaxProductiveTime", DataStore.MaxProductiveTime);
            //Preferences.Set("Factor", DataStore.Factor);
            //Preferences.Set("ProdSeconds", DataStore.ProdSeconds);
        }

        public static void Clear() => Preferences.Clear();
    }
}
