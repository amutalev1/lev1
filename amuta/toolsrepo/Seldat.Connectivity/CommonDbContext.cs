
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Connectivity
{
    public class CommonDbContext
    {
        #region Members

        // Note: Static initializers are thread safe.
        public static readonly string DataProvider = ConfigurationManager.AppSettings["DataProvider"];
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(DataProvider);
        private string _connectionString = null;
        #endregion

        #region CTORs
        public CommonDbContext() : this("DefaultConnection")
        {

        }
        public CommonDbContext(string connectionStringName)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
        public CommonDbContext(DbConnectionStringBuilder connectionStringBuilder)
        {
            _connectionString = connectionStringBuilder.ConnectionString;
        }

        public int Insert(object insertTable, bool v, IList<DbParameter> parameters)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Data Update handlers
        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public int Update(string sql)
        {
            return Update(sql, null);
        }
        /// <summary>
        /// Executes Update statements in the database using parameters. Generaly for blobs and othr complex types.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"> array of db parameters</param>
        /// <returns></returns>
        public int Update(string sql, IList<DbParameter> parameters)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    if(parameters!=null)
                    for (int i = 0; i < parameters.Count; i++)
                        command.Parameters.Add(parameters[i]);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Executes insert statements in the database using parameters. Generaly for blobs and othr complex types.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"> collection of db parameters</param>
        /// <returns></returns>
        public int Insert(string sql, bool getId, IList<DbParameter> parameters)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                using (DbCommand command = factory.CreateCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        if (parameters != null)
                            for (int i = 0; i < parameters.Count; i++)
                                command.Parameters.Add(parameters[i]);

                        connection.Open();
                        int id = -1;
                        command.CommandText = sql;
                        id = command.ExecuteNonQuery();
                        // Check if new identity is needed.
                        if (getId)
                        {
                            sql = GetQueryOfIdentityColumn();
                            command.CommandText = sql;
                            id = int.Parse(command.ExecuteScalar().ToString());
                        }

                        return id;
                    }
                    catch (Exception ex) { throw new Exception("Error at insert statement. /p/n SQL:" + sql, ex); }
                }
            }
        }
        /// <summary>
        /// Executes Insert statements in the database. Optionally returns new identifier.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="getId">Value indicating whether newly generated identity is returned.</param>
        /// <returns>Newly generated identity value (autonumber value).</returns>
        public int Insert(string sql, bool getId)
        {
            return Insert(sql, getId, null);
        }
        /// <summary>
        /// Executes Insert statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        public int Insert(string sql)
        {
            return Insert(sql, false);
        }
        /// <summary>
        /// Executes Delete statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public int Delete(string sql)
        {
            return Delete(sql, null);
        }

        public int Delete(string sql, IList<DbParameter> parameters)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = sql;
                        if (parameters != null)
                            for (int i = 0; i < parameters.Count; i++)
                                command.Parameters.Add(parameters[i]);

                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch (Exception ex) {
                        throw new Exception("Error at delete statement. /p/n SQL:" + sql);
                    }
                }
            }
        }
        #endregion

        #region Data Retrieve Handlers

        public DataSet GetDataSet(string sql)
        {
            return GetDataSet(sql, null);
        }
       
        /// <summary>
        /// Populates a DataSet according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataSet.</returns>
        public DataSet GetDataSet(string sql, IList<DbParameter> parameters)
        {
            try
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;

                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.Text;
                        command.CommandText = sql;
                        if (parameters != null && parameters.Count > 0)
                            foreach (DbParameter parameter in parameters)
                                command.Parameters.Add(parameter);

                        using (DbDataAdapter adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(sql, ex);
            }
        }
        /// <summary>
        /// Populates a DataTable according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataTable.</returns>
        public DataTable GetDataTable(string sql, IList<DbParameter> parameters)
        {
            DataTable table = GetDataSet(sql, parameters).Tables[0];
            if (table == null || table.Rows.Count == 0) return null;
            return table;
        }
        /// <summary>
        /// Populates a DataRow according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataRow.</returns>
        public DataRow GetDataRow(string sql, IList<DbParameter> parameters)
        {
            DataRow row = null;
            DataTable dt = GetDataTable(sql, parameters);
            if (dt == null) return null;
            if (dt.Rows.Count > 0)
                row = dt.Rows[0];
            return row;
        }

        public object GetScalar(string sql)
        {
            return GetScalar(sql, null);
        }
        /// <summary>
        /// Executes a Sql statement and returns a scalar value.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Scalar value.</returns>
        public object GetScalar(string sql, IList<DbParameter> parameters)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = _connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    if (parameters != null && parameters.Count > 0)
                        foreach (DbParameter parameter in parameters)
                            command.Parameters.Add(parameter);
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception err)
                    {
                        throw new Exception(sql, err);
                    }
                    return command.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// Execute stored procedure, 
        /// </summary>
        /// <param name="StoredProcedure">Stored procedure name</param>
        /// <param name="columnName">Array of column name</param>
        /// <param name="parameters">List of DBParameters</param>
        /// <returns></returns>
        public DataSet StoredProcedure_GetDataSet(string storedProcedureName, IList<DbParameter> parameters)
        {
            try
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;

                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = storedProcedureName;

                        for (int i = 0; i < parameters.Count; i++)
                            command.Parameters.Add(parameters[i]);

                        using (DbDataAdapter adapter = factory.CreateDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            return ds;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public DataTable StoredProcedure_GetDataTable(string storedProcedureName, IList<DbParameter> parameters)
        {
            return StoredProcedure_GetDataSet(storedProcedureName, parameters).Tables[0];
        }

        public DataRow StoredProcedure_GetDataRow(string storedProcedureName, IList<DbParameter> parameters)
        {
            return StoredProcedure_GetDataTable(storedProcedureName, parameters).Rows[0];
        }


        public void StoredProcedure_Execute(string storedProcedureName, ref IList<DbParameter> parameters)
        {
            try
            {
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = _connectionString;

                    using (DbCommand command = factory.CreateCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = storedProcedureName;

                        for (int i = 0; i < parameters.Count; i++)
                            command.Parameters.Add(parameters[i]);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public object StoredProcedure_ExecuteScalar(string storedProcedureName, ref IList<DbParameter> parameters)
        {
            return StoredProcedure_GetDataRow(storedProcedureName, parameters)[0];
        }
        #endregion

        #region Utility methods

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>Escaped output string.</returns>
        public string Escape(string s)
        {
            return Escape(s, true);
        }
        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// <param name="s"></param>
        /// <param name="addApostrophes"></param>
        /// <returns></returns>
        public string Escape(string s, bool addApostrophes)
        {
            if (s.Trim() == "NULL") return "NULL";
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
            {
                if (addApostrophes)
                    return "'" + s.Trim().Replace("'", "''") + "'";
                else
                    return s.Trim().Replace("'", "''");
            }
        }
        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// <param name="s"></param>
        /// <param name="addApostrophes"></param>
        /// <param name="isUnicode"></param>
        /// <returns></returns>
        public string AddUnicode(string s, bool isUnicode)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";

            return isUnicode ? "N'" + s.Trim().Replace("'", "''") + "'" : "'" + s.Trim().Replace("'", "''") + "'";
        }
        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// Also trims string at a given maximum length.
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="maxLength">Maximum length of output string.</param>
        /// <returns>Escaped output string.</returns>
        public string Escape(string s, int maxLength)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
            {
                s = s.Trim();
                if (s.Length > maxLength) s = s.Substring(0, maxLength - 1);
                return "'" + s.Trim().Replace("'", "''") + "'";
            }
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// this methos take sqlQuery and retrieve the table name in this query
        /// </summary>
        /// MTS
        /// <param name="sqlQuery">Sql Query</param>
        /// <returns>Table name</returns>
        private static string GetTableNameFromSqlQuery(string sqlQuery)
        {
            sqlQuery = sqlQuery.ToLower();
            sqlQuery = sqlQuery.Remove(0, sqlQuery.IndexOf("into") + 4).Trim();
            return sqlQuery.Substring(0, sqlQuery.IndexOf(" "));
        }

        private string GetQueryOfIdentityColumn()
        {
            switch (DataProvider)
            {
                // Access
                case "System.Data.OleDb":
                    return "SELECT @@IDENTITY";
                // Sql Server
                case "System.Data.SqlClient":
                    return "SELECT SCOPE_IDENTITY()";
                default:
                    return "SELECT @@IDENTITY";
            }
        }
        private string buildSqlPlusIdentity(string sql)
        {
            switch (DataProvider)
            {
                // Access
                case "System.Data.OleDb":
                    return sql + "; SELECT @@IDENTITY";
                // Sql Server
                case "System.Data.SqlClient":
                    return sql + "; SELECT SCOPE_IDENTITY()";
                // Oracle
                case "System.Data.OracleClient":
                    return sql;
                default:
                    return sql + "; SELECT @@IDENTITY";
            }
        }
        private static int getIdFromQuery(DbCommand command)
        {
            switch (DataProvider)
            {
                case "System.Data.SqlClient":
                    return int.Parse(command.ExecuteScalar().ToString());
                default:
                    throw new Exception("");
            }
        }

        #endregion
    }
}
