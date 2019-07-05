using System.Collections.Generic;

namespace Seldat.Amuta.Entities.Managers
{
   public interface IStreetDataManager
    {
        int InsertStreet(Street street);
        List<Street> GetStreetsByCity(int id);
        Street GetStreet(int id);
    }
}
