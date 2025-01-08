using MurderAPI.Entities;
using MurderAPI.Models;

namespace MurderAPI.Services
{
    public interface ISuspectsService
    {
        bool GetAllSuspects(out List<Suspect>? result);
        bool GetSuspectById(int id, out Suspect? result);
    }
    public class SuspectsService : ISuspectsService
    {
        private readonly ISuspectsModel _suspectsModel;

        public SuspectsService(ISuspectsModel suspectsModel)
        {
            _suspectsModel = suspectsModel;
        }

        public bool GetAllSuspects(out List<Suspect>? result)
        {
            result = _suspectsModel.GetAllSuspects();
            return result != null;
        }

        public bool GetSuspectById(int id, out Suspect? result)
        {
            result = _suspectsModel.GetSuspectById(id);
            return result != null;
        }
    }
}
