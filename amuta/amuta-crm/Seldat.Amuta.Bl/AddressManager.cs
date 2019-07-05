using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Utils;
using System;
using System.Transactions;
using Unity;

namespace Seldat.Amuta.BL
{
    public class AddressManager
    {
        private static readonly IBaseLogger _logger;

        static AddressManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        #region Managers

        static IAddressDataManager _addressDataManager;
        public static IAddressDataManager AddressDataManager
        {
            get
            {
                if (_addressDataManager == null)
                {
                    _addressDataManager = DIManager.Container.Resolve<IAddressDataManager>();
                }
                return _addressDataManager;
            }
        }

        static ICountryDataManager _countryDataManager;
        static ICountryDataManager CountryDataManager
        {
            get
            {
                if (_countryDataManager == null)
                {
                    _countryDataManager = DIManager.Container.Resolve<ICountryDataManager>();
                }
                return _countryDataManager;
            }
        }

        static ICityDataManager _cityDataManager;
        static ICityDataManager CityDataManager
        {
            get
            {
                if (_cityDataManager == null)
                {
                    _cityDataManager = DIManager.Container.Resolve<ICityDataManager>();
                }
                return _cityDataManager;
            }
        }

        static IStreetDataManager _streetDataManager;
        static IStreetDataManager StreetDataManager
        {
            get
            {
                if (_streetDataManager == null)
                {
                    _streetDataManager = DIManager.Container.Resolve<IStreetDataManager>();
                }
                return _streetDataManager;
            }
        }

        #endregion

        private static Address insertNewCityAndNewStreet(Address address)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    if (address.City != null && !(address.City.Id > 0))
                    {
                        address.City.Country.Id = address.Country.Id;
                        address.City.Id = CityDataManager.InsertCity(address.City);
                    }
                    if (address.Street != null && !(address.Street.Id > 0))
                    {
                        address.Street.City.Id = address.City.Id;
                        address.Street.Id = StreetDataManager.InsertStreet(address.Street);
                    }

                    scope.Complete();
                    return address;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Failed to save city/street", ex);
                throw;
            }
        }

        public static int InsertAddress(Address address)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    address = insertNewCityAndNewStreet(address);
                    int insert = AddressDataManager.InsertAddress(address);
                    scope.Complete();
                    return insert;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Failed to insert adddress", ex);
                throw;
            }
        }

        public static int UpdateAddress(Address address)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    int save;
                    address = insertNewCityAndNewStreet(address);
                    if (address.Id > 0)
                        save = AddressDataManager.UpdateAddress(address);
                    else
                        save =address.Id= AddressDataManager.InsertAddress(address);
                    scope.Complete();
                    return save;
                }
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to update adddress {address.Id}", ex);
                throw;
            }
        }

        static public Address GetAddress(int id)
        {
            try
            {
                Address address = AddressDataManager.GetAddress(id);
                address.Country = CountryDataManager.GetCountry(address.Country.Id);
                address.City = CityDataManager.GetCity(address.City.Id);
                address.Street = StreetDataManager.GetStreet(address.Street.Id);
                return address;
            }
            catch (Exception ex)
            {
                _logger.Debug($"Failed to get adddress {id}.", ex);
                throw;
            }
        }
    }
}