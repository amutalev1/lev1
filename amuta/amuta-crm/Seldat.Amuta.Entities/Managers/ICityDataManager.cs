using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
    public interface ICityDataManager
    {
        int InsertCity(City city);
        List<City> GetCitiesByCountry(int id);
        City GetCity(int id);
    }
}
