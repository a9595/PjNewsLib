using System.Threading.Tasks;

namespace NewsMVVMtest.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}