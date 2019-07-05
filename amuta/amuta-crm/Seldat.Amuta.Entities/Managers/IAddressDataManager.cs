namespace Seldat.Amuta.Entities.Managers
{
    public interface IAddressDataManager
    {
        int InsertAddress(Address address);
        int UpdateAddress(Address address);
        //TODO: do we need it?
        int DeleteAddress(int id);
        Address GetAddress(int id);
    }
}
