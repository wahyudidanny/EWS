using EWS.Services.Models;

namespace EWS.Services.Interface
{
    public interface IDataService
    {
         IEnumerable<T_MsBusinessUnit> GetDataBusinessUnit();
    }
}