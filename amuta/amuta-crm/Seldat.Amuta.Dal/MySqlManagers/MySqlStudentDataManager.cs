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
    public class MySqlStudentDataManager : IStudentDataManager
    {
        private CommonDbContext _dbContext = null;

        public MySqlStudentDataManager()
        {
            _dbContext = new CommonDbContext();
        }

        private string GetQueryForMultipleTables(Student.Includes includes)
        {
            string selectStatement = $"SELECT {Tables.Students.allColumnsAlias} ";
            string fromStatement = $" FROM {Tables.Students.TableName} ";

            if (includes.HasFlag(Student.Includes.Bank))
            {
                selectStatement += $", {Tables.Banks.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.Banks.TableName} ON " +
                        $"{Tables.Banks.TableName}.{Tables.Banks.Id.Name} = {Tables.Students.TableName}.{Tables.Students.BankId.Name} ";
            }

            if (includes.HasFlag(Student.Includes.Address))
            {
                selectStatement += $",{Tables.Address.allColumnsAlias},{Tables.Countries.allColumnsAlias},{Tables.Cities.allColumnsAlias},{Tables.Streets.allColumnsAlias} ";
                fromStatement += $" LEFT JOIN {Tables.Address.TableName} ON " +
                        $" {Tables.Address.TableName}.{Tables.Address.Id.Name} = {Tables.Students.TableName}.{Tables.Students.AddressId.Name}" +
                        $" LEFT JOIN {Tables.Countries.TableName} ON  {Tables.Address.TableName}.{Tables.Address.CountryId.Name}= {Tables.Countries.TableName}.{Tables.Countries.Id.Name} " +
                        $" LEFT JOIN {Tables.Cities.TableName} ON  {Tables.Address.TableName}.{Tables.Address.CityId.Name}={Tables.Cities.TableName}.{Tables.Cities.Id.Name} " +
                        $" LEFT JOIN {Tables.Streets.TableName} ON  {Tables.Address.TableName}.{Tables.Address.StreetId.Name}={Tables.Streets.TableName}.{Tables.Streets.Id.Name} ";
            }

            if (includes.HasFlag(Student.Includes.Children))
            {
                selectStatement += $", {Tables.StudentsChildren.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.StudentsChildren.TableName} ON " +
                    $"{Tables.StudentsChildren.TableName}.{Tables.StudentsChildren.StudentId.Name} = {Tables.Students.TableName}.{Tables.Students.Id.Name} ";
            }

            if (includes.HasFlag(Student.Includes.BranchStudent))
            {
                selectStatement += $", {Tables.BranchStudents.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.BranchStudents.TableName} ON " +
                    $"{Tables.BranchStudents.TableName}.{Tables.BranchStudents.StudentId.Name} = {Tables.Students.TableName}.{Tables.Students.Id.Name} ";
            }

            if (includes.HasFlag(Student.Includes.Branch))
            {
                selectStatement += $", {Tables.Branches.allColumnsAlias}";
                fromStatement += $" LEFT JOIN {Tables.Branches.TableName} ON " +
                    $"{Tables.Branches.TableName}.{Tables.Branches.Id.Name} = {Tables.BranchStudents.TableName}.{Tables.BranchStudents.BranchId.Name} ";
            }

            string sql = selectStatement + fromStatement;
            return sql;
        }

        public Students GetAllStudents(Student.Includes includes,int? from,int? amount)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@fromRow",from),
                new MySqlParameter("@amount",amount)
            };
            string limitStatement = string.Empty;
            if (from != null && amount != null)
            {
                limitStatement += $" Limit @fromRow, @amount ";
            }
            string sql = "CREATE TEMPORARY TABLE tmp_students " + GetQueryForMultipleTables(includes) + ";" +
              $" CREATE TEMPORARY TABLE tmp_students_ids select distinct {Tables.Students.Id.FullName} from tmp_students " + limitStatement + ";" +
              $"  SELECT * from tmp_students where {Tables.Students.Id.FullName} in(SELECT * from tmp_students_ids);" +
              $" DROP TEMPORARY TABLE tmp_students, tmp_students_ids; ";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.TableToStudent(table, includes);
            return new Students();
        }

        public Students GetStudentsOfBranch(int branchId,Student.Includes includes, int? from, int? amount)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", branchId),
                new MySqlParameter("@fromRow",from),
                new MySqlParameter("@amount",amount)
            };

            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Branches.TableName}.{Tables.Branches.Id.Name}=@id";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.TableToStudent(table, includes);
            return null;
        }

        public Student GetStudent(int studentId, Student.Includes includes)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", studentId)
            };

            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Students.TableName}.{Tables.Students.Id.Name}=@id";

            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.RowToStudent(table.AsEnumerable(), includes);
            return null;
        }
        public Student GetStudentByIdentityNumber(int studentIdentityNumber, Student.Includes includes)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@identity_number", studentIdentityNumber)
            };

            string sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Students.TableName}.{Tables.Students.IdentityNumber.Name}=@identity_number";
                                                                                                                                          
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.RowToStudent(table.AsEnumerable(), includes);
            return null;
        }
        public Students GetPendingStudents(Student.Includes includes)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@status","pending"),
                new MySqlParameter("@is_active",false)
            };
            string sql = GetQueryForMultipleTables(includes) + $"LEFT JOIN {Tables.BranchStudents.TableName} ON " +
               $" {Tables.Students.TableName}.{Tables.Students.Id.Name} = {Tables.BranchStudents.TableName}.{Tables.BranchStudents.StudentId.Name}" +
               $" WHERE {Tables.BranchStudents.TableName}.{Tables.BranchStudents.Status.Name}=@status AND {Tables.BranchStudents.TableName}.{Tables.BranchStudents.IsActive.Name}=@is_active";
            DataTable table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.TableToStudent(table, includes);
            return null;
        }

        public Student GetPendingStudent(int studentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
                new MySqlParameter("@id", studentId),
                new MySqlParameter("@status","pending"),
                new MySqlParameter("@is_active",false)
            };

            string sql = $"SELECT * FROM {Tables.Students.TableName} JOIN {Tables.BranchStudents.TableName} ON " +
               $" {Tables.Students.TableName}.{Tables.Students.Id.Name} = {Tables.BranchStudents.TableName}.{Tables.BranchStudents.Id.Name}" +
               $" WHERE {Tables.BranchStudents.Status.Name}=@status AND {Tables.BranchStudents.IsActive.Name}=@is_active AND {Tables.Students.Id.Name}=@number";

            DataTable dataTable = _dbContext.GetDataTable(sql, parameters);
            return StudentConverter.RowToStudent(dataTable.AsEnumerable(), Student.Includes.None);
        }

        //public Students GetStudentsByBranchId(int id)
        //{
        //    IList<DbParameter> parameters = new List<DbParameter>()
        //    {
        //       new MySqlParameter("@id",id),
        //       new MySqlParameter("@status","approved"),
        //       new MySqlParameter("@is_active",true)
        //    };

        //    string sql = $"SELECT * FROM {Tables.Students.TableName} JOIN {Tables.BranchStudents.TableName} ON" +
        //        $" {Tables.Students.TableName}.{Tables.Students.Id.Name}={Tables.BranchStudents.TableName}.{Tables.BranchStudents.Id.Name} " +
        //        $" WHERE {Tables.BranchStudents.Status.Name}=@status AND {Tables.BranchStudents.IsActive.Name}=@is_active AND {Tables.BranchStudents.BranchId.Name}=@id";

        //    DataTable table = _dbContext.GetDataTable(sql, null);
        //    if (table != null)
        //        return StudentConverter.TableToStudent(table, Student.Includes.None);
        //    return new Students();
        //}

        public int InsertPendingStudent(Student student)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@account_number",student.AccountNumber!=null?student.AccountNumber:null), 
               new MySqlParameter("@first_name",student.FirstName),
               new MySqlParameter("@last_name",student.LastName),
               new MySqlParameter("@address_id",student.Address.Id),
               new MySqlParameter("@bank_id", student.Bank.Id),
               new MySqlParameter("@born_date", student.BornDate),
               new MySqlParameter("@cellphone_number", student.CellphoneNumber!=null?student.CellphoneNumber:null),
               new MySqlParameter("@children_number", student.ChildrenNumber!=null?student.ChildrenNumber:null),
               new MySqlParameter("@fax_number", student.FaxNumber!=null?student.FaxNumber:null),
               new MySqlParameter("@id_card", student.IdCard),
               new MySqlParameter("@identity_number", student.IdentityNumber),
               new MySqlParameter("@image", student.Image),
               new MySqlParameter("@job_wife", student.JobWife!=null?student.JobWife:null),
               new MySqlParameter("@married_children_number",student.MarriedChildrenNumber!=null?student.MarriedChildrenNumber:null),
               new MySqlParameter("@monthly_income", student.MonthlyIncome!=null?student.MonthlyIncome:null),
               new MySqlParameter("@travel_expenses", student.TravelExpenses!=null?student.TravelExpenses:null),
               new MySqlParameter("@wife_name", student.WifeName!=null?student.WifeName:null),
               new MySqlParameter("@phone_number", student.PhoneNumber),
               new MySqlParameter("@travel_expenses_currency",student.TravelExpensesCurrency!=null?student.TravelExpensesCurrency:null),
               new MySqlParameter("@monthly_income_currency",student.MonthlyIncomeCurrency!=null?student.MonthlyIncomeCurrency:null),
               new MySqlParameter("@is_active", student.IsActive)
           };

            return _dbContext.Insert(Tables.Students.InsertTable, true, parameters);
        }
        public int InsertStudentPayment(StudentPayment studentPayment)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
               new MySqlParameter("@student_id",studentPayment.Student.Id),
               new MySqlParameter("@month",studentPayment.Month),
               new MySqlParameter("@year",studentPayment.Year),
               new MySqlParameter("@payment_sum",studentPayment.PaymentSum),
               new MySqlParameter("@attendance_sum",studentPayment.AttendanceSum),
               new MySqlParameter("@exams_sum",studentPayment.ExamsSum),
               new MySqlParameter("@state_budget_sum",studentPayment.StateBudgetSum),
               new MySqlParameter("@health_support_sum",studentPayment.HealthSupportSum),
               new MySqlParameter("@dental_health_support_sum",studentPayment.DentalHealthSupportSum ),
               new MySqlParameter("@financial_support_sum",studentPayment.FinancialSupportSum),
               new MySqlParameter("@loans_given_sum",studentPayment.LoansGivenSum ),
               new MySqlParameter("@loans_return_sum",studentPayment.LoansReturnSum ),
           };

            return _dbContext.Insert(Tables.StudentPayment.InsertTable, true, parameters);
        }
        public int UpdateStudent(Student student)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
            {
               new MySqlParameter("@id",student.Id),
               new MySqlParameter("@account_number",student.AccountNumber!=null?student.AccountNumber:null),
               new MySqlParameter("@first_name",student.FirstName),
               new MySqlParameter("@last_name",student.LastName),
               new MySqlParameter("@address_id",student.Address.Id),
               new MySqlParameter("@bank_id", student.Bank.Id),
               new MySqlParameter("@born_date", student.BornDate),
               new MySqlParameter("@cellphone_number", student.CellphoneNumber!=null?student.CellphoneNumber:null),
               new MySqlParameter("@children_number", student.ChildrenNumber!=null?student.ChildrenNumber:null),
               new MySqlParameter("@fax_number", student.FaxNumber!=null?student.FaxNumber:null),
               new MySqlParameter("@id_card", student.IdCard),
               new MySqlParameter("@identity_number", student.IdentityNumber),
               new MySqlParameter("@image", student.Image),
               new MySqlParameter("@job_wife", student.JobWife!=null?student.JobWife:null),
               new MySqlParameter("@married_children_number",student.MarriedChildrenNumber!=null?student.MarriedChildrenNumber:null),
               new MySqlParameter("@monthly_income", student.MonthlyIncome!=null?student.MonthlyIncome:null),
               new MySqlParameter("@travel_expenses", student.TravelExpenses!=null?student.TravelExpenses:null),
               new MySqlParameter("@wife_name", student.WifeName!=null?student.WifeName:null),
               new MySqlParameter("@phone_number", student.PhoneNumber),
               new MySqlParameter("@is_active", student.IsActive),
                new MySqlParameter("@travel_expenses_currency",student.TravelExpensesCurrency!=null?student.TravelExpensesCurrency:null),
               new MySqlParameter("@monthly_income_currency",student.MonthlyIncomeCurrency!=null?student.MonthlyIncomeCurrency:null),

            };
            return _dbContext.Update(Tables.Students.UpdateTable, parameters);
        }

        public int SetStudentInactive(int studentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@number",studentId),
              new MySqlParameter("@is_active",false)
           };
            string sql = $"UPDATE {Tables.Students.TableName} SET {Tables.Students.IsActive.Name}=@is_active" +
                $" WHERE {Tables.Students.Id.Name}=@number";
            return _dbContext.Update(sql, parameters);
        }

        public int SetStudentActive(int studentId)
        {
            IList<DbParameter> parameters = new List<DbParameter>()
           {
              new MySqlParameter("@number",studentId),
              new MySqlParameter("@is_active",true)
           };
            string sql = $"UPDATE {Tables.Students.TableName} SET {Tables.Students.IsActive.Name}=@is_active" +
                $" WHERE {Tables.Students.Id.Name}=@number AND {Tables.Students.IsActive.Name}!=@is_active";
            return  _dbContext.Update(sql, parameters);
        }

        public decimal GetPayment(int studentId)
        {
            //TODO
            
            IList<DbParameter> parameters = new List<DbParameter>()
            {               
               new MySqlParameter("@id",studentId)
            };
            string sql;
            //todo add query and change the return value
            return 1;
        }

        public bool IsExistIdentityNumber(string identityNumber, int studentId)
        {

            IList<DbParameter> parameters = new List<DbParameter>()
            {
               new MySqlParameter("@identity_number",identityNumber),
               new MySqlParameter("@id",studentId)
            };

            string sql = $"SELECT {Tables.Students.TableName}.* FROM {Tables.Students.TableName}" +
                $" WHERE {Tables.Students.IdentityNumber.Name}=@identity_number AND {Tables.Students.Id.Name}!=@id";
            return _dbContext.GetScalar(sql, parameters) != null; 
        }
        public Students Contains(Student.Includes includes, string str)
        {
            IList<DbParameter> parameters = new List<DbParameter>() { };

            string sql = $"select column_name from INFORMATION_SCHEMA.COLUMNS where table_name = 'students' and column_name not like '%date%'";
            DataTable table = _dbContext.GetDataTable(sql, parameters);

            List<string> st = new List<string>();
            for (int i = 0; i < table.Rows.Count; i++)
                st.Add(table.Rows[i].ItemArray[0].ToString());

            string strings = " ";
            for (int i = 1; i < table.Rows.Count - 1; i++)
                strings += " or students." + st[i] + " LIKE '%" + str + "%' ";

            //if (str == null)
            //    sql = GetQueryForMultipleTables(includes);
            //else
            sql = GetQueryForMultipleTables(includes) + $" WHERE {Tables.Students.TableName}." + st[0] + " LIKE '%" + str + "%'" + strings + ";";


            table = _dbContext.GetDataTable(sql, parameters);
            if (table != null)
                return StudentConverter.TableToStudent(table, includes);
            return null;
        }

    }
}
