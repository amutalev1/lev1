using Seldat.Amuta.Entities;
using Seldat.AspNet.Identity.Entities;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class BranchStaffConverter
    {
        public static BranchStaff RowToBranchStaff(DataRow row)
        {
            return new BranchStaff()
            {
                Branch =new Branch() { Id=DataRowHelper.GetValue<int>(row, Tables.BranchStaff.BranchId.Name)}, 
                User =new UserExtraDetails() { UserId=DataRowHelper.GetValue<string>(row, Tables.BranchStaff.UserId.Name)} ,   
                Role=new Role() { Id=DataRowHelper.GetValue<string>(row,Tables.BranchStaff.RoleId.Name)}
            };
        }
        public static List<BranchStaff> TableToBranchStaff(DataTable table)
        {
            if (table == null)
                return null;
            List<BranchStaff> branchStaff = new List<BranchStaff>();
            foreach (DataRow row in table.Rows)
            {
                branchStaff.Add(RowToBranchStaff(row));
            }
            return branchStaff;
        }
    }
}
