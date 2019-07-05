using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
    public interface ICountryDataManager
    {
        int InsertCountry(Country country);
        List<Country> GetCountries();
        Country GetCountry(int id);
    }
}
