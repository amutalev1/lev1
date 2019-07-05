using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
    public class BranchConverter
    {
        //in the middle
        public static Branch RowToBranch(IEnumerable<DataRow>rows,Branch.Includes includes)
        {
            DataRow row = rows.FirstOrDefault();
            return new Branch()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.Branches.Id.FullName),
                Address =includes.HasFlag(Branch.Includes.Address)?AddressConverter.RowToAddress(row):null,
                Head = includes.HasFlag(Branch.Includes.UserExtraDetails) ? UserExtraDetailsConverter.RowToUserExtraDetails(row) : null,
                Image = DataRowHelper.GetValue<string>(row, Tables.Branches.Image.FullName),
                IsActive = DataRowHelper.GetValue<bool>(row, Tables.Branches.IsActive.FullName),
                Name = DataRowHelper.GetValue<string>(row, Tables.Branches.Name.FullName),
                OpeningDate = DataRowHelper.GetValue<DateTime>(row, Tables.Branches.OpeningDate.FullName),
                StudentsNumber = DataRowHelper.GetValue<int>(row, Tables.Branches.StudentsNumber.FullName),
                Type =includes.HasFlag(Branch.Includes.BranchType)?BranchTypeConverter.RowToBranchType(row):null,
                StudySubjects = DataRowHelper.GetValue<string>(row, Tables.Branches.StudySubjects.FullName),
                ExamRules=includes.HasFlag(Branch.Includes.Rules)?BranchRulesConverter.RowToExamRules(row):null,
                AttendanceRules = includes.HasFlag(Branch.Includes.Rules) ? BranchRulesConverter.RowToAttendanceRules(row) : null,
                ActivityHours = includes.HasFlag(Branch.Includes.ActivityHours) ? rows.GroupBy(branchRow => DataRowHelper.GetValue<int>(branchRow, Tables.BranchActivityHours.Id.FullName),
                (id, hour) => BranchActivityHoursConverter.RowToBranchActivityHours(hour.CopyToDataTable().AsEnumerable())).ToList() : null,   
                Institution=includes.HasFlag(Branch.Includes.Institution)?InstitutionConverter.RowToInstitution(row):null
            };
        }
        public static Branches TableToBranch(DataTable table,Branch.Includes includes)
        {
            if (table == null)
                return null;
            Branches branches = new Branches();
            var branchList = table.AsEnumerable().GroupBy(row => DataRowHelper.GetValue<int>(row, Tables.Branches.Id.FullName),
                  (key, group) => RowToBranch(group, includes));
            branches.AddRange(branchList.ToList());
            return branches;
        }
    }
}