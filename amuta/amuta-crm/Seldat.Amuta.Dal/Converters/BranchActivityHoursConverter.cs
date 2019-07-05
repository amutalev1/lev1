using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class BranchActivityHoursConverter
    {
        //public static BranchActivityHours RowToBranchActivityHours(IEnumerable<DataRow> rows)
        //{
        //    DataRow row = rows.FirstOrDefault();
        //    return new BranchActivityHours()
        //    {
        //        Id = DataRowHelper.GetValue<int>(row, Tables.BranchActivityHours.Id.FullName),
        //        Branch = null,
        //        LateHour = DataRowHelper.GetValue<TimeSpan>(row, Tables.BranchActivityHours.LateHour.FullName),
        //        EndStudyHours = DataRowHelper.GetValue<TimeSpan>(row, Tables.BranchActivityHours.EndStudyHours.FullName)
        //    };
        //}
        public static BranchActivityHours RowToBranchActivityHours(IEnumerable<DataRow> rows)
        {
            DataRow row = rows.FirstOrDefault();
            return new BranchActivityHours()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.BranchActivityHours.Id.Name),
                Branch = new Branch() { Id = DataRowHelper.GetValue<int>(row, Tables.BranchActivityHours.BranchId.Name)},
                LateHour = DataRowHelper.GetValue<TimeSpan>(row, Tables.BranchActivityHours.LateHour.Name),
                EndStudyHours = DataRowHelper.GetValue<TimeSpan>(row, Tables.BranchActivityHours.EndStudyHours.Name),
                StartStudyHours = DataRowHelper.GetValue<TimeSpan>(row, Tables.BranchActivityHours.StartStudyHours.Name)
            };


        }
        public static List<BranchActivityHours> TableToBranchActivityHours(DataTable table)
        {
            if (table == null)
                return null;
            List<BranchActivityHours> branchActivityHours = new List<BranchActivityHours>();
            foreach (DataRow row in table.Rows)
            {
                branchActivityHours.Add(RowToBranchActivityHours(table.AsEnumerable()));
            }
            return branchActivityHours;
        }
       




    }
}
