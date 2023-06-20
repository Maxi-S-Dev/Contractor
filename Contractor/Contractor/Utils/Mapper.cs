using Contractor.Model;
using Contractor.Services;

namespace Contractor.Utils
{
    public static class Mapper
    {
        public static void SaveDataToAppData(SaveDataModel saveData)
        {
            DataStore ds = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;

            ds.ProdSeconds = saveData.ProdSeconds;
            ds.FreeSeconds = saveData.FreeSeconds;

            ds.Factor = saveData.Factor;

            ds.MaxProductiveTime= saveData.MaxProductiveTime;
            ds.MaxFreeTime = saveData.MaxFreeTime;

            ds.lastDate = saveData.lastDate;
        }

        public static SaveDataModel AppDataToSaveData() 
        {
            DataStore ds = Application.Current.Handler.MauiContext.Services.GetService(typeof(DataStore)) as DataStore;
            SaveDataModel saveData = new SaveDataModel();


            saveData.ProdSeconds = ds.ProdSeconds;
            saveData.FreeSeconds = (int)ds.FreeSeconds;

            saveData.Factor = ds.Factor;

            saveData.MaxProductiveTime = ds.MaxProductiveTime;
            saveData.MaxFreeTime = ds.MaxFreeTime;

            saveData.lastDate = ds.lastDate;
            return saveData;
        }
    }
}
