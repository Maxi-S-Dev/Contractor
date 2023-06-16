using Contractor.Model;
using Contractor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contractor.Utils
{
    public static class Mapper
    {
        private static DataStore ds = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;

        public static void SaveDataToAppData(SaveDataModel saveData)
        {
            //DataStore ds = Application.Current.Handler.MauiContext.Handlers.GetService(typeof(DataStore)) as DataStore;
            
            ds.ProdSeconds = saveData.ProdSeconds;
            ds.FreeSeconds = saveData.FreeSeconds;

            ds.Factor = saveData.Factor;

            ds.MaxProductiveTime= saveData.MaxProductiveTime;
            ds.MaxFreeTime = saveData.MaxFreeTime;
        }

        public static SaveDataModel AppDataToSaveData() 
        {
            //DataStore ds = Application.Current.Handler.MauiContext.Handlers.GetService(typeof(DataStore)) as DataStore;
            SaveDataModel saveData = new SaveDataModel();


            saveData.ProdSeconds = ds.ProdSeconds;
            saveData.FreeSeconds = (int)ds.FreeSeconds;

            saveData.Factor = ds.Factor;

            saveData.MaxProductiveTime = ds.MaxProductiveTime;
            saveData.MaxFreeTime = ds.MaxFreeTime;
            return saveData;
        }
    }
}
