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
    public class StudentConverter
    {
        private static IBaseLogger _logger;
        static StudentConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }

        public static Student RowToStudent(IEnumerable<DataRow> rows, Student.Includes include)
        {
            DataRow row = rows.FirstOrDefault();
            BranchesStudents branchesStudent = new BranchesStudents();
            if (include.HasFlag(Student.Includes.BranchStudent))
            {
                var studentInstoitutionList = rows.GroupBy(studentRow => DataRowHelper.GetValue<int>(studentRow, Tables.BranchStudents.Id.FullName),
              (id, group) => BranchStudentConverter.RowToBranchStudent(group.CopyToDataTable().AsEnumerable(),Student.Includes.Branch)).ToList();
                branchesStudent.AddRange(studentInstoitutionList);
            }

            return new Student()
            {
                FirstName = DataRowHelper.GetValue<string>(row, Tables.Students.FirstName.FullName),
                LastName = DataRowHelper.GetValue<string>(row, Tables.Students.LastName.FullName),
                AccountNumber = DataRowHelper.GetValue<string>(row, Tables.Students.AccountNumber.FullName),
                Bank = include.HasFlag(Student.Includes.Bank) ? BankConverter.RowToBank(row) : null,
                Address = include.HasFlag(Student.Includes.Address) ? AddressConverter.RowToAddress(row) : null,
                BornDate = DataRowHelper.GetValue<DateTime>(row, Tables.Students.BornDate.FullName),
                PhoneNumber = DataRowHelper.GetValue<string>(row, Tables.Students.PhoneNumber.FullName),
                CellphoneNumber = DataRowHelper.GetValue<string>(row, Tables.Students.CellphoneNumber.FullName),
                ChildrenNumber = DataRowHelper.GetValue<int>(row, Tables.Students.ChildrenNumber.FullName),
                FaxNumber = DataRowHelper.GetValue<string>(row, Tables.Students.FaxNumber.FullName),
                IdCard = DataRowHelper.GetValue<string>(row, Tables.Students.IdCard.FullName),
                IdentityNumber = DataRowHelper.GetValue<string>(row, Tables.Students.IdentityNumber.FullName),
                Image = DataRowHelper.GetValue<string>(row, Tables.Students.Image.FullName),
                JobWife = DataRowHelper.GetValue<string>(row, Tables.Students.JobWife.FullName),
                MarriedChildrenNumber = DataRowHelper.GetValue<int>(row, Tables.Students.MarriedChildrenNumber.FullName),
                MonthlyIncome = DataRowHelper.GetValue<decimal>(row, Tables.Students.MonthlyIncome.FullName),
                Id = DataRowHelper.GetValue<int>(row, Tables.Students.Id.FullName),
                TravelExpenses = DataRowHelper.GetValue<decimal>(row, Tables.Students.TravelExpenses.FullName),
                WifeName = DataRowHelper.GetValue<string>(row, Tables.Students.WifeName.FullName),
                StudentChildren = include.HasFlag(Student.Includes.Children) ? rows.GroupBy(studentRow => DataRowHelper.GetValue<int>(studentRow, Tables.StudentsChildren.Id.FullName),
                (id, child) => StudentChildrenConverter.RowToStudentChildren(child.CopyToDataTable().AsEnumerable())).ToList() : null,
                StudentBranches = include.HasFlag(Student.Includes.BranchStudent) ? branchesStudent : null,
                IsActive= DataRowHelper.GetValue<bool>(row, Tables.Students.IsActive.FullName)
            };
        }

        public static Students TableToStudent(DataTable table, Student.Includes include)
        {
            if (table == null)
                return null;
            Students students = new Students();
            var studentList = table.AsEnumerable().GroupBy(row => DataRowHelper.GetValue<int>(row, Tables.Students.Id.FullName),
                 (key, group) => RowToStudent(group, include));
            students.AddRange(studentList.ToList());
            return students;
        }
    }
}
