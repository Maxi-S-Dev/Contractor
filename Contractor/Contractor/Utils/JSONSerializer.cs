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
            SaveDataModel saveData = JsonSerializer.Deserialize<SaveDataModel>(jsonString);

            return saveData;
        }
    }
}
