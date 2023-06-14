using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Container
{
    public static class SaveData
    {
        public static void Load()
        {
            DataStorage.MaxFreeTime = Preferences.Get("MaxFreeTime", 6);
            DataStorage.MaxProductiveTime = Preferences.Get("MaxProductiveTime", 8);
            //DataStorage.Factor = (float)Preferences.Get("Factor", 1.75);
            DataStorage.ProdSeconds = Preferences.Get("ProdSeconds", 0);
        }

        public static void Save() 
        {
            Preferences.Set("MaxFreeTime", DataStorage.MaxFreeTime);
            Preferences.Set("MaxProductiveTime", DataStorage.MaxProductiveTime);
            Preferences.Set("Factor", DataStorage.Factor);
            Preferences.Set("ProdSeconds", DataStorage.ProdSeconds);
        }  

        public static void Clear() => Preferences.Clear();
    }
}
