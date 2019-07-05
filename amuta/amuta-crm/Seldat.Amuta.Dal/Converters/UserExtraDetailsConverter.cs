using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System.Collections.Generic;
using System.Data;
using Unity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    internal class UserExtraDetailsConverter
    {
        private static IBaseLogger _logger;
        static UserExtraDetailsConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        public static UserExtraDetails RowToUserExtraDetails(DataRow row)
        {
            return new UserExtraDetails()
            {
                Identitynumber = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.IdentityNumber.FullName),
                Address = new Address() { Id = DataRowHelper.GetValue<int>(row, Tables.UserExtraDetails.AddressId.FullName) },
                Image = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.Image.FullName),
                CellphoneNumber = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.CellphoneNumber.FullName),
                PhoneNumber = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.PhoneNumber.FullName),
                UserId = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.UserId.FullName),
                Email = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.Email.FullName),
                FirstName = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.FirstName.FullName),
                LastName = DataRowHelper.GetValue<string>(row, Tables.UserExtraDetails.LastName.FullName),              
            };
        }
        public static List<UserExtraDetails> TableToUserExtraDetails(DataTable table)
        {
            if (table == null)
                return null;
            List<UserExtraDetails> userExtraDetails = new List<UserExtraDetails>();
            foreach (DataRow row in table.Rows)
            {
                userExtraDetails.Add(RowToUserExtraDetails(row));
            }
            return userExtraDetails;
        }

    }
}