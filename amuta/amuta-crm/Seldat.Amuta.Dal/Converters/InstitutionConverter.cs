using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
   public class InstitutionConverter
    {
        public static Institution RowToInstitution(DataRow row)
        {
            return new Institution()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Institutions.Id.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Institutions.Name.FullName),         
            };
        }

    }
}
