using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using static Seldat.Amuta.Dal.DbContent;
namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlBranchStudentDataManager : IBranchStudentDataManager
    {
        private CommonDbContext _dbContext = new CommonDbContext();

        private string GetQueryForMultipleTables(Student.Includes includes)
        {
            string selectStatement = $"SELECT {Tables.BranchStudents.allColumnsAlias} ";
            string fromStatement = $" FROM {Tables.BranchStudents.TableName} ";

            if (includes.HasFlag(Student.Includes.Branch))
            {
                selectStatement += $", {Tables.Branches.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.Branches.TableName} ON " +
                        $"{Tables.Branches.TableName}.{Tables.Branches.Id.Name} = {Tables.BranchStudents.TableName}.{Tables.BranchStudents.BranchId.Name} ";
            }

            string sql = selectStatement + fromStatement;
            return sql;
        }

        public BranchesStudents GetAllStudentsToBranch(int branchId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@branch_id",branchId),
                new MySqlParameter("@is_active",true),
                new MySqlParameter("@status",StatusInBranch.Approved.ToString())
            };
            string sql = $"SELECT {Tables.BranchStudents.allColumnsAlias} FROM {Tables.BranchStudents.TableName} WHERE {Tables.BranchStudents.BranchId.Name}=@branch_id" +
                $" AND {Tables.BranchStudents.IsActive.Name}=@is_active AND {Tables.BranchStudents.Status.Name}=@status";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table);
            return new BranchesStudents();
        }

        //public int RequestRegistrationBranchStudent(BranchStudent branchStudent)
        //{
        //    IList<DbParameter> parameters = new List<DbParameter>()
        //   {
        //      new MySqlParameter("@student_id",branchStudent.Student.Id),
        //      new MySqlParameter("@branch_id",branchStudent.Branch.Id),
        //      new MySqlParameter("@branch_study_track_id",branchStudent.studyTrack.Id),
        //      new MySqlParameter("@status","pending"),
        //      new MySqlParameter("@is_active",false)
        //   };
        //    string sql = $"INSERT INTO {Tables.BranchStudents.TableName} (student_id,branch_id,status,is_active) VALUES (@student_id,@branch_id,@status,@is_active)";
        //    return _dbContext.Insert(sql, true, parameters);
        //}


        //מקורי
        //public int RequestRegistrationBranchStudent(int studentId, int branchId, int? studyPathId)
        //{
        //    IList<DbParameter> parameters = new List<DbParameter>()
        //   {
        //      new MySqlParameter("@student_id",studentId),
        //      new MySqlParameter("@branch_id",branchId),
        //      new MySqlParameter("@branch_study_path_id",studyPathId),
        //      new MySqlParameter("@entry_gregorian_date",null),
        //      new MySqlParameter("@entry_hebrew_date",null),
        //      new MySqlParameter("@release_hebrew_date",null),
        //      new MySqlParameter("@release_gregorian_date",null),
        //      new MySqlParameter("@status",StatusInBranch.Pending.ToString()),
        //      new MySqlParameter("@is_active",false)
        //   };
        //    return _dbContext.Insert(Tables.BranchStudents.InsertTable, true, parameters);
        //}

        //שלי

        

        public int SetStudentInactiveInBranch(int studentId, int branchId, string releaseHebrewDate)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@student_id",studentId),
              new MySqlParameter("@branch_id",branchId),
              new MySqlParameter("@release_gregorian_date",DateTime.UtcNow),
              new MySqlParameter("@releaseHebrewDate",releaseHebrewDate),
              new MySqlParameter("@is_active",false)
           };
            string sql = $"UPDATE {Tables.BranchStudents.TableName} SET {Tables.BranchStudents.IsActive.Name}=@is_active,{Tables.BranchStudents.ReleaseGregorianDate.Name}=@release_gregorian_date, " +
                $" {Tables.BranchStudents.ReleaseHebrewDate.Name}=@releaseHebrewDate  WHERE {Tables.BranchStudents.StudentId.Name}=@student_id " +
                $"AND {Tables.BranchStudents.BranchId.Name}=@branch_id AND {Tables.BranchStudents.IsActive.Name}!=@is_active";
            return _dbContext.Update(sql, parameters);
        }

        public int ApprovalRegistrationStudent(int branchStudentId, string entryHebrewDate)
        {

            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@id",branchStudentId),
              new MySqlParameter("@entry_gregorian_date",DateTime.UtcNow),
              new MySqlParameter("@entry_hebrew_date",entryHebrewDate),
              new MySqlParameter("@status",StatusInBranch.Approved.ToString()),
              new MySqlParameter("@is_active",true)
           };
            //TODO: enter datetime in some lands (where is the server?)?get from the client
            string sql = $"UPDATE {Tables.BranchStudents.TableName} SET {Tables.BranchStudents.Status.Name}=@status, {Tables.BranchStudents.IsActive.Name}=@is_active," +
                $" {Tables.BranchStudents.EntryGregorianDate.Name}=@entry_gregorian_date, {Tables.BranchStudents.EntryHebrewDate.Name}=@entry_hebrew_date" +
                $" WHERE {Tables.BranchStudents.Id.Name}=@id AND {Tables.BranchStudents.Status.Name}!=@status";

            return _dbContext.Update(sql, parameters);
        }

        public int RegistrationStudentToBranch(int studentId, int branchId, string entryHebrewDate)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@branch_id",branchId),
              new MySqlParameter("@student_id",studentId),
              new MySqlParameter("@branch_study_path_id",null),
              new MySqlParameter("@entry_gregorian_date",DateTime.UtcNow),
              new MySqlParameter("@entry_hebrew_date",entryHebrewDate),
              new MySqlParameter("@release_hebrew_date",null),
              new MySqlParameter("@release_gregorian_date",null),
              new MySqlParameter("@status",StatusInBranch.Approved.ToString()),
              new MySqlParameter("@is_active",true),
              new MySqlParameter("@is_head",false)
           };

            //TODO: enter datetime in some lands (where is the server?)?get from the client
            return _dbContext.Insert(Tables.BranchStudents.InsertTable, true, parameters);
        }

        public BranchesStudents GetBranchesOfStudent(int studentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id",studentId)
            };

            string sql = $"SELECT {Tables.BranchStudents.allColumnsAlias} FROM {Tables.BranchStudents.TableName} WHERE {Tables.BranchStudents.StudentId.Name}=@id";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table);
            return new BranchesStudents();
        }

        public BranchesStudents GetBranchesOfPendingStudent(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id",id),
                new MySqlParameter("@is_active",false),
                new MySqlParameter("@status",StatusInBranch.Pending.ToString())
            };

            string sql = $"SELECT {Tables.BranchStudents.allColumnsAlias} FROM {Tables.BranchStudents.TableName} WHERE {Tables.BranchStudents.StudentId.Name}=@id" +
                $" AND {Tables.BranchStudents.IsActive.Name}=@is_active AND {Tables.BranchStudents.Status.Name}=@status";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table);
            return new BranchesStudents();
        }

        public BranchesStudents GetBranchesInactiveStudent(int studentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id",studentId),
                new MySqlParameter("@is_active",false),
            };

            string sql = $"SELECT {Tables.BranchStudents.allColumnsAlias} FROM {Tables.BranchStudents.TableName} WHERE {Tables.BranchStudents.StudentId.Name}=@id" +
                $" AND {Tables.BranchStudents.IsActive.Name}=@is_active";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table);
            return new BranchesStudents();
        }

        public int SetStudentActiveInBranch(int branchStudentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@id",branchStudentId),
              new MySqlParameter("@is_active",true),
              new MySqlParameter("@status",StatusInBranch.Approved.ToString())
           };

            string sql = $"UPDATE {Tables.BranchStudents.TableName} SET {Tables.BranchStudents.IsActive.Name}=@is_active" +
                $" WHERE {Tables.BranchStudents.Status.Name}=@status AND {Tables.BranchStudents.Id.Name}=@id";

            return _dbContext.Update(sql, parameters);
        }

        public BranchesStudents GetBranchesOfPendingStudents()
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@status",StatusInBranch.Pending.ToString()),
                new MySqlParameter("@is_active",false),
            };

            string sql = $"SELECT * FROM {Tables.BranchStudents.TableName} WHERE {Tables.BranchStudents.Status.Name}=@status" +
                $" AND {Tables.BranchStudents.IsActive.Name}=@is_active";

            DataTable table = _dbContext.GetDataTable(Tables.BranchStudents.SelectAllTable, null);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table);
            return new BranchesStudents();
        }

        public BranchesStudents GetActiveBranchesOfStudent(int studentId, Student.Includes includes = Student.Includes.None)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@is_active",true),
                new MySqlParameter("@student_id",studentId)
            };

            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.BranchStudents.TableName}.{Tables.BranchStudents.IsActive.Name}=@is_active AND {Tables.BranchStudents.StudentId.Name}=@student_id ";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchStudentConverter.TableToBranchStudent(table, includes);
            return new BranchesStudents();
        }
        public int MakeBranchStudentsInactive(int branchId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@is_active",false),
                new MySqlParameter("@branch_id",branchId)
            };
            string sql = $"UPDATE {Tables.BranchStudents.TableName} SET {Tables.BranchStudents.IsActive.Name} = @is_active"+
            $" WHERE {Tables.BranchStudents.BranchId.Name} = @branch_id";
            return _dbContext.Update(sql, parameters);
        }


        public int RequestRegistrationBranchStudent(BranchStudent branchStudent)
        {
                  
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@student_id",branchStudent.Student.Id),//branchStudent.Student.Id
              new MySqlParameter("@branch_id",branchStudent.Branch.Id),//branchStudent.Branch.Id
              new MySqlParameter("@branch_study_path_id",1),//branchStudent.StudyPath.Id
              new MySqlParameter("@entry_gregorian_date",branchStudent.EntryGregorianDate),
              new MySqlParameter("@entry_hebrew_date",branchStudent.EntryHebrewDate),
              new MySqlParameter("@release_hebrew_date",branchStudent.ReleaseHebrewDate),
              new MySqlParameter("@release_gregorian_date",branchStudent.ReleaseGregorianDate),
              new MySqlParameter("@status",StatusInBranch.Pending.ToString()),
              new MySqlParameter("@is_active",false)
           };
            return _dbContext.Insert(Tables.BranchStudents.InsertTable, true, parameters);
        }

        public int RequestRegistrationBranchStudent(int studentId, int branchId, int? studyPathId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@student_id",studentId),
              new MySqlParameter("@branch_id",branchId),
              new MySqlParameter("@branch_study_path_id",studyPathId),
              new MySqlParameter("@entry_gregorian_date",null),
              new MySqlParameter("@entry_hebrew_date",null),
              new MySqlParameter("@release_hebrew_date",null),
              new MySqlParameter("@release_gregorian_date",null),
              new MySqlParameter("@status",StatusInBranch.Pending.ToString()),
              new MySqlParameter("@is_active",false),
              new MySqlParameter("@is_head",false)
           };
            return _dbContext.Insert(Tables.BranchStudents.InsertTable, true, parameters);
        }
    }
}
