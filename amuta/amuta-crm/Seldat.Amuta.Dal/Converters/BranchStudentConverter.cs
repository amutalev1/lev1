using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using static Seldat.Amuta.Dal.DbContent;


namespace Seldat.Amuta.Dal.Converters
{
   public class BranchStudentConverter
    {
        public static BranchStudent RowToBranchStudent(IEnumerable<DataRow> rows,Student.Includes includes=Student.Includes.None)
        {
            DataRow row = rows.FirstOrDefault();
            return new BranchStudent()
            {
                Id = DataRowHelper.GetValue<int>(row, Tables.BranchStudents.Id.FullName),
                EntryGregorianDate = DataRowHelper.GetValue<DateTime>(row, Tables.BranchStudents.EntryGregorianDate.FullName),
                EntryHebrewDate = DataRowHelper.GetValue<DateTime>(row, Tables.BranchStudents.EntryHebrewDate.FullName),
                Branch = includes.HasFlag(Student.Includes.Branch) ? BranchConverter.RowToBranch(rows,Branch.Includes.Address):null,
                ReleaseGregorianDate = DataRowHelper.GetValue<DateTime>(row, Tables.BranchStudents.ReleaseGregorianDate.FullName) ,
                ReleaseHebrewDate = DataRowHelper.GetValue<DateTime>(row, Tables.BranchStudents.ReleaseHebrewDate.FullName),
                IsActive = DataRowHelper.GetValue<bool>(row, Tables.BranchStudents.IsActive.FullName),
                Student =new Student() { Id = DataRowHelper.GetValue<int>(row, Tables.BranchStudents.StudentId.FullName) },
                //Status=(StatusInBranch)Enum.Parse(typeof(StatusInBranch), DataRowHelper.GetValue<string>(row, Tables.BranchStudents.Status.FullName), true),
               
            };
        }
        public static BranchesStudents TableToBranchStudent(DataTable table, Student.Includes includes= Student.Includes.None)
        {
            if (table == null)
                return null;
           BranchesStudents branchesStudents = new BranchesStudents();
            foreach (DataRow row in table.Rows)
            {
                branchesStudents.Add(RowToBranchStudent(table.AsEnumerable(),includes));
            }
            return branchesStudents;
        }
    }
}
