using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System.Collections.Generic;
using System.Data;
using Unity;
using static Seldat.Amuta.Dal.DbContent;
namespace Seldat.Amuta.Dal.Converters
{
   public class BranchRulesConverter
    {
        public static ExamRules RowToExamRules(DataRow row)
        {
            return new ExamRules()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.ExamsRules.Id.FullName),
                Branch =null,
                ExamsPeriod = DataRowHelper.GetValue<string>(row, Tables.ExamsRules.ExamsPeriod.FullName),
                ExamsPerPeriod = DataRowHelper.GetValue<int>(row, Tables.ExamsRules.ExamsPerPeriod.FullName),
                IsRequiredExams = DataRowHelper.GetValue<bool>(row, Tables.ExamsRules.IsRequiredExams.FullName)      
            };
        }
        public static AttendanceRules RowToAttendanceRules(DataRow row)
        {
            return new AttendanceRules()
            {
                Branch =null,
                Id = DataRowHelper.GetValue<int>(row, Tables.AttendanceRules.Id.FullName),
                MaximumAbsences = DataRowHelper.GetValue<int>(row, Tables.AttendanceRules.MaximumAbsences.FullName),
                MaximumLateness = DataRowHelper.GetValue<int>(row, Tables.AttendanceRules.MaximumLateness.FullName)
            };
        }
        //public static List<BranchProcedure> TableToBranchProcedure(DataTable table)
        //{
        //    if (table == null)
        //        return null;
        //    List<BranchProcedure> branchProcedure = new List<BranchProcedure>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        branchProcedure.Add(RowToBranchProcedure(row));
        //    }
        //    return branchProcedure;
        //}
    }
}
