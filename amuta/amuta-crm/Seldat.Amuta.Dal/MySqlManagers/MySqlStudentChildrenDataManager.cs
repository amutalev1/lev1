using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static Seldat.Amuta.Dal.DbContent;

namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlStudentChildrenDataManager : IStudentChildrenDataManager
    {
        private CommonDbContext _dbContext = null;
        public MySqlStudentChildrenDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        //public List<StudentChildren> GetStudentChildren(int id)
        //{
        //    IList<DbParameter> parameters = new List<DbParameter>()
        //    {
        //        new MySqlParameter("@id",id),
        //    };

        //    string sql = $"SELECT {Tables.StudentsChildren.TableName}.* FROM {Tables.StudentsChildren.TableName}" +
        //        $" WHERE {Tables.StudentsChildren.StudentId.Name} = @id";

        //    DataTable table = _dbContext.GetDataTable(sql, parameters);
        //    if (table != null)
        //        return StudentChildrenConverter.TableToStudentChildren(table);
        //    return new List<StudentChildren>();
        //}

        public int InsertStudentChildren(StudentChildren studentChildren)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@student_id",studentChildren.Student.Id),
               new MySqlParameter("@first_name", studentChildren.FirstName),
               new MySqlParameter("@last_name", studentChildren.LastName),
               new MySqlParameter("@gender", studentChildren.Gender),
               new MySqlParameter("@age", studentChildren.Age),
               new MySqlParameter("@status", studentChildren.Status),
           };

            return _dbContext.Insert(Tables.StudentsChildren.InsertTable, true, parameters);
        }

        public int UpdateStudentChildren(StudentChildren studentChildren)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
               new MySqlParameter("@id",studentChildren.Id),
               new MySqlParameter("@student_id",studentChildren.Student.Id),
               new MySqlParameter("@first_name", studentChildren.FirstName),
               new MySqlParameter("@last_name", studentChildren.LastName),
               new MySqlParameter("@gender", studentChildren.Gender),
               new MySqlParameter("@age", studentChildren.Age),
               new MySqlParameter("@status", studentChildren.Status),
            };

            return _dbContext.Update(Tables.StudentsChildren.UpdateTable, parameters);
        }

    }
}
