using System.Threading.Tasks;

namespace PjNewsLibMvvmLightTRY.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}