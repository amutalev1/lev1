using Seldat.Amuta.Entities;
using Seldat.Connectivity;
using Seldat.Utils;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.Converters
{
  public  class StudentChildrenConverter
    {
        private static IBaseLogger _logger;
        static StudentChildrenConverter()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        public static StudentChildren RowToStudentChildren(IEnumerable<DataRow> rows)
        {
            DataRow row = rows.FirstOrDefault();
            if (row == null)
                return null;
            return new StudentChildren()
            {
                Age = DataRowHelper.GetValue<decimal>(row, Tables.StudentsChildren.Age.FullName),
                FirstName =DataRowHelper.GetValue<string>(row, Tables.StudentsChildren.FirstName.FullName),
                LastName = DataRowHelper.GetValue<string>(row, Tables.StudentsChildren.LastName.FullName),
                Gender = DataRowHelper.GetValue<string>(row, Tables.StudentsChildren.Gender.FullName),
                Id = DataRowHelper.GetValue<int>(row, Tables.StudentsChildren.Id.FullName),
                Status = DataRowHelper.GetValue<string>(row, Tables.StudentsChildren.Status.FullName),
                Student= null
            };
        }

        public static List<StudentChildren> TableToStudentChildren(DataTable table)
        {
            if (table == null)
                return null;
            List<StudentChildren> studentChildrens = new List<StudentChildren>();
            foreach (DataRow row in table.Rows)
            {
                studentChildrens.Add(RowToStudentChildren(table.AsEnumerable()));
            }
            return studentChildrens;
        }
    }
}
