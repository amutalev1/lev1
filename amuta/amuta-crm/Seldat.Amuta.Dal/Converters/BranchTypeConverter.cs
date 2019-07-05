using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
   public class BranchTypeConverter
    {
        public static BranchType RowToBranchType(DataRow row)
        {
            return new BranchType()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.BranchTypes.Id.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.BranchTypes.Name.FullName),
                Type = DataRowHelper.GetValue<string>(row, Tables.BranchTypes.Type.FullName),              
            };
        }
    }
}
