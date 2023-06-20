using Contractor.Model;
using System.Text.Json;

namespace Contractor.Utils
{
    public static class JSONSerializer
    {
        internal static string SaveDataToJSON(SaveDataModel saveData)
        {
            string jsonString = JsonSerializer.Serialize(saveData);

            return jsonString;
        }

        internal static SaveDataModel JSONToSaveData(string jsonString)
        {
            if(string.IsNullOrEmpty(jsonString)) return null;
            SaveDataModel saveData = JsonSerializer.Deserialize<SaveDataModel>(jsonString);

            return saveData;
        }
    }
}
