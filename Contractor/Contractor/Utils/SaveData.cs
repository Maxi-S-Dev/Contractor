using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Utils
{
    public static class SaveData
    {
        public static void Load()
        {
            DataStore.MaxFreeTime = Preferences.Get("MaxFreeTime", 6);
            DataStore.MaxProductiveTime = Preferences.Get("MaxProductiveTime", 8);
            //DataStore.Factor = (float)Preferences.Get("Factor", 1.75);
            DataStore.ProdSeconds = Preferences.Get("ProdSeconds", 0);
        }

        public static void Save()
        {
            Preferences.Set("MaxFreeTime", DataStore.MaxFreeTime);
            Preferences.Set("MaxProductiveTime", DataStore.MaxProductiveTime);
            Preferences.Set("Factor", DataStore.Factor);
            Preferences.Set("ProdSeconds", DataStore.ProdSeconds);
        }

        public static void Clear() => Preferences.Clear();
    }
}
