

namespace Seldat.Amuta.Entities.Managers
{
   public interface IScolarshipDataManager
    {
        int InsertScolarship(Scolarship scolarship);
        int UpdateScolarship(Scolarship scolarship);
        Scolarship GetScolarship(int id);
    }
}
