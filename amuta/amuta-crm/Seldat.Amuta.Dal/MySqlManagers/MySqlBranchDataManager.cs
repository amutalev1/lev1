using MySql.Data.MySqlClient;
using Seldat.Amuta.Dal.Converters;
using Seldat.Amuta.Entities;
using Seldat.Amuta.Entities.Managers;
using Seldat.Connectivity;
using Seldat.Utils;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Unity;
using static Seldat.Amuta.Dal.DbContent;
namespace Seldat.Amuta.Dal.MySqlManagers
{
    public class MySqlBranchDataManager : IBranchDataManager
    {
        static readonly IBaseLogger _logger;
        static MySqlBranchDataManager()
        {
            _logger = DIManager.Container.Resolve<IBaseLogger>();
        }
        private CommonDbContext _dbContext = new CommonDbContext();
        private string GetQueryForMultipleTables(Branch.Includes includes)
        {
            string selectStatement = $"SELECT {Tables.Branches.allColumnsAlias} ";
            string fromStatement = $" FROM {Tables.Branches.TableName} ";

            if (includes.HasFlag(Branch.Includes.Rules))
            {
                selectStatement += $", {Tables.ExamsRules.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.ExamsRules.TableName} ON " +
                        $"{Tables.ExamsRules.TableName}.{Tables.ExamsRules.BranchId.Name} = {Tables.Branches.TableName}.{Tables.Branches.Id.Name} ";
                selectStatement += $", {Tables.AttendanceRules.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.AttendanceRules.TableName} ON " +
                        $"{Tables.AttendanceRules.TableName}.{Tables.AttendanceRules.BranchId.Name} = {Tables.Branches.TableName}.{Tables.Branches.Id.Name} ";
            }
            if (includes.HasFlag(Branch.Includes.Address))
            {
                selectStatement += $",{Tables.Address.allColumnsAlias},{Tables.Countries.allColumnsAlias},{Tables.Cities.allColumnsAlias},{Tables.Streets.allColumnsAlias} ";
                fromStatement += $" LEFT JOIN {Tables.Address.TableName} ON " +
                        $" {Tables.Address.TableName}.{Tables.Address.Id.Name} = {Tables.Branches.TableName}.{Tables.Branches.AddressId.Name}" +
                        $" LEFT JOIN {Tables.Countries.TableName} ON  {Tables.Address.TableName}.{Tables.Address.CountryId.Name}= {Tables.Countries.TableName}.{Tables.Countries.Id.Name} " +
                        $" LEFT JOIN {Tables.Cities.TableName} ON  {Tables.Address.TableName}.{Tables.Address.CityId.Name}={Tables.Cities.TableName}.{Tables.Cities.Id.Name} " +
                        $" LEFT JOIN {Tables.Streets.TableName} ON  {Tables.Address.TableName}.{Tables.Address.StreetId.Name}={Tables.Streets.TableName}.{Tables.Streets.Id.Name} ";
            }
            if (includes.HasFlag(Branch.Includes.ActivityHours))
            {
                selectStatement += $", {Tables.BranchActivityHours.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.BranchActivityHours.TableName} ON " +
                    $"{Tables.BranchActivityHours.TableName}.{Tables.BranchActivityHours.BranchId.Name} = {Tables.Branches.TableName}.{Tables.Branches.Id.Name} ";
            }

            if (includes.HasFlag(Branch.Includes.BranchType))
            {
                selectStatement += $", {Tables.BranchTypes.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.BranchTypes.TableName} ON " +
                    $"{Tables.BranchTypes.TableName}.{Tables.BranchTypes.Id.Name} = {Tables.Branches.TableName}.{Tables.Branches.TypeId.Name} ";
            }
            if (includes.HasFlag(Branch.Includes.Institution))
            {
                selectStatement += $", {Tables.Institutions.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.Institutions.TableName} ON " +
                    $"{Tables.Institutions.TableName}.{Tables.Institutions.Id.Name} = {Tables.Branches.TableName}.{Tables.Branches.InstitutionId.Name} ";
            }
            if (includes.HasFlag(Branch.Includes.UserExtraDetails))
            {
                //include the head
                selectStatement += $", {Tables.UserExtraDetails.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.UserExtraDetails.TableName} ON " +
                    $"{Tables.UserExtraDetails.TableName}.{Tables.UserExtraDetails.UserId.Name} = {Tables.Branches.TableName}.{Tables.Branches.HeadId.Name} ";
            }
            if (includes.HasFlag(Branch.Includes.Scolarship))
            {            
                //selectStatement += $", {Tables.Scolarships.allColumnsAlias}";
                //fromStatement += $" LEFT JOIN {Tables.Scolarships.TableName} ON " +
                //    $"{Tables.Scolarships.TableName}.{Tables.Scolarships.Id.Name} = {Tables.Branches.TableName}.{Tables.Branches.} ";
            }
            string sql = selectStatement + fromStatement;
            return sql;
        }

        public Branches GetBranchesByType(int id, Branch.Includes includes)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };
            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Branches.TypeId.Name}=@id";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchConverter.TableToBranch(table, includes);
            return new Branches();
        }

        public int InsertBranch(Branch branch)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@type_id",branch.Type.Id),
              new MySqlParameter("@head_id",branch.Head.UserId),
              new MySqlParameter("@address_id",branch.Address.Id),
              new MySqlParameter("@name",branch.Name),
              new MySqlParameter("@opening_date",branch.OpeningDate),
              //defult 0
              new MySqlParameter("@students_number","0"),
              new MySqlParameter("@study_subjects",branch.StudySubjects),
              new MySqlParameter("@is_active",branch.IsActive),
              new MySqlParameter("@image",branch.Image),
              new MySqlParameter("@institution_id",branch.Institution.Id),
           };
            return _dbContext.Insert(Tables.Branches.InsertTable, true, parameters);
        }
        public int UpdateBranch(Branch branch)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@id",branch.Id),
              new MySqlParameter("@type_id",branch.Type.Id),
              new MySqlParameter("@head_id",branch.Head.UserId),
              new MySqlParameter("@address_id",branch.Address.Id),
              new MySqlParameter("@name",branch.Name),
              new MySqlParameter("@opening_date",branch.OpeningDate),
              new MySqlParameter("@students_number",branch.StudentsNumber),
              new MySqlParameter("@study_subjects",branch.StudySubjects),
              new MySqlParameter("@is_active",branch.IsActive),
              new MySqlParameter("@image",branch.Image),
              new MySqlParameter("@institution_id",branch.Institution.Id)
           };
            return _dbContext.Update(Tables.Branches.UpdateTable, parameters);
        }
        public int MakeBranchInactive(int id)
        {

            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@isActive",false),
              new MySqlParameter("@id",id),
           };
            string sql = $"UPDATE {Tables.Branches.TableName} SET {Tables.Branches.IsActive.Name}=@isActive WHERE {Tables.Branches.Id.Name}=@id";
            return _dbContext.Update(sql, parameters);
        }
        public Branch GetBranchById(int id, Branch.Includes includes)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id)
            };
            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Branches.TableName}.{Tables.Branches.Id.Name}= @id";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchConverter.RowToBranch(table.AsEnumerable(), includes);
            return null;
        }
        public Branches GetNotActiveBranchesByType(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", id),
                new MySqlParameter("@isActive",false)
            };
            string sql = $"SELECT * FROM {Tables.Branches.TableName} WHERE {Tables.Branches.TypeId.Name}=@id AND {Tables.Branches.IsActive.Name}=@isActive";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            //if (table != null)
            //return BranchConverter.TableToBranch(table);
            return new Branches();
        }
        public int MakeBranchActive(int id)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@isActive",true),
              new MySqlParameter("@id",id),
           };
            string sql = $"UPDATE {Tables.Branches.TableName} SET {Tables.Branches.IsActive.Name}=@isActive WHERE {Tables.Branches.Id.Name}=@id";
            return _dbContext.Update(sql, parameters);
        }

        public int IncreaseNumberOfStudents(int branchId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@id",branchId)
           };
            string sql = $"UPDATE {Tables.Branches.TableName} SET {Tables.Branches.StudentsNumber.Name}={Tables.Branches.StudentsNumber.Name}+1" +
                $" WHERE {Tables.Branches.Id.Name}=@id";
            return _dbContext.Update(sql, parameters);
        }

        public int ReduceNumberOfStudents(int institutionId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@id",institutionId)
           };
            string sql = $"UPDATE {Tables.Branches.TableName} SET {Tables.Branches.StudentsNumber.Name}={Tables.Branches.StudentsNumber.Name}-1" +
                $" WHERE {Tables.Branches.Id.Name}=@id";
            return _dbContext.Update(sql, parameters);
        }

        public Branches Contains(Branch.Includes includes, string str)
        {
            IList<DbParameter> parameters = new List<DbParameter>() { };

            string sql = $"select column_name from INFORMATION_SCHEMA.COLUMNS where table_name = 'branches' and column_name not like '%date%'";
            DataTable table = _dbContext.GetDataTable(sql, parameters);

            List<string> st = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
                st.Add(table.Rows[i].ItemArray[0].ToString());

            string strings = " ";
            for (int i = 1; i < table.Rows.Count - 1; i++)
                strings += " or branches." + st[i] + " LIKE '%" + str + "%' ";

            sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Branches.TableName}.{Tables.Branches.Name.Name}  LIKE '%" + str + "%';";


            table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return BranchConverter.TableToBranch(table, includes);
            return null;
        }

        public int Delete(Branch branch)
        {
            IList<DbParameter> parameters = new List<DbParameter>() { };

            string sql = "delete from branch_activity_hours where branch_id = " + branch.Id + ";" +
                "delete from branch_exams where branch_id = " + branch.Id + ";" +
                "delete from branch_staff where branch_id = " + branch.Id + ";" +
                "delete from branch_students where branch_id = " + branch.Id + ";" +
                "delete from financial_support_request where branch_id = " + branch.Id + ";" +
                "delete from branch_study_path where branch_id = " + branch.Id + ";" +
                "delete from loan_support_request where branch_id = " + branch.Id + ";" +
                "delete from health_support_request where branch_id = " + branch.Id + ";" +
                "delete from attendance where branch_id = " + branch.Id + ";" +
                "delete from attendance_rules where branch_id = " + branch.Id + ";" +
                "delete from dental_health_support_request where branch_id = " + branch.Id + ";" +
                "delete from branches where id = " + branch.Id + ";";
            return _dbContext.Delete(sql, parameters);
        }



    }
}
