using MurderAPI.Entities;
using System.Text.Json;

namespace MurderAPI.Models
{
    public interface ISuspectsModel
    {
        public List<Suspect>? GetAllSuspects();
        Suspect? GetSuspectById(int id);
    }
    public class SuspectsModel : ISuspectsModel
    {
        public List<Suspect>? GetAllSuspects()
        {
            return JsonSerializer.Deserialize<List<Suspect>>(File.ReadAllText("Json_Data\\Suspects.json"));
        }

        public Suspect? GetSuspectById(int id)
        {
            return GetAllSuspects()?.FirstOrDefault(s => s.Id == id);
        }
    }
}
