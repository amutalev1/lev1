using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace Seldat.DBMapper
{
    public class DbMapperSqlite : IDbMapper
    {
        string allColumnsAlias;
        public DbConnection Connection { get; set; }

        public DbMapperSqlite(string ConStr)
        {
            try
            {
                Connection = new SQLiteConnection(ConStr);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured in creating MySqlConnection Object:");
                Console.WriteLine(ex.Message);
            }
        }

        public void MapDataBase(string outputPath, string TargetNameSpace)
        {
            try
            {
                Connection.Open();
                // get schemas of Db Objects: tables, Sp, views
                DataTable columnSchema = Connection.GetSchema("columns");
                DataTable tableSchema = Connection.GetSchema("tables");
                //DataTable routineSchema = Connection.GetSchema("procedures", new[] { Connection.Database, null });
                // DataTable routineParams = Connection.GetSchema("procedure parameters", new[] { Connection.Database, null });
                //DataTable viewSchema = Connection.GetSchema("views", new[] { "", null });

                var tables = columnSchema.AsEnumerable().GroupBy(t => t["TABLE_NAME"]);
                //var procedures = routineSchema.Select("ROUTINE_TYPE = 'PROCEDURE'");
                //var procParams = routineParams.Select("ROUTINE_TYPE = 'PROCEDURE'");
                //var functions = routineSchema.Select("ROUTINE_TYPE = 'FUNCTION'");
                //var funcParams = routineParams.Select("ROUTINE_TYPE = 'FUNCTION'");

                using (StreamWriter writer = new StreamWriter(outputPath))
                {

                    //Can to be const in template file;
                    writer.WriteLine(string.Format("namespace {0}", TargetNameSpace));
                    writer.WriteLine("{");
                    writer.WriteLine("\tpublic static class DbContent");
                    writer.WriteLine("\t{");
                    string text = System.IO.File.ReadAllText(@"C:\projects\toolsrepo\Template.txt");
                    writer.WriteLine(text);


                    #region Tables
                    writer.WriteLine("\t\tpublic static class Tables");
                    writer.WriteLine("\t\t{");

                    tableSchema.AsEnumerable().ToList().ForEach(t =>
                    {
                        allColumnsAlias = "";
                        writer.WriteLine("\t\t\t/// <summary>");
                        //if (!string.IsNullOrEmpty(t["TABLE_COMMENT"].ToString()))
                        //    writer.WriteLine("\t\t///" + t["TABLE_COMMENT"]);
                        writer.WriteLine("\t\t\t/// </summary>");
                        var tableName = NamingConvention.SetNamingConvention(t["TABLE_NAME"].ToString());
                        writer.WriteLine("\t\t\tpublic static class {0}", tableName);
                        writer.WriteLine("\t\t\t{");
                        writer.WriteLine("\t\t\tpublic static string TableName  = \"{0}\";", t["TABLE_NAME"]);
                        writer.WriteLine("\t\t\tpublic static string SelectAllTable  = \"Select * from {0}\";", t["TABLE_NAME"]);
                        string UpdateTable = $"Update {t["TABLE_NAME"]} set ";
                        string Select = $"Select * from {t["TABLE_NAME"]}";
                        string Delete = $"Delete from {t["TABLE_NAME"]}";
                        string InsertTable = $"Insert into {t["TABLE_NAME"]}(";
                        string Values = $"Values(";
                        string id = "";
                        DataRow[] columns = columnSchema.Select("TABLE_NAME = '" + t["TABLE_NAME"] + "'");

                        columns.ToList().ForEach(c =>
                        {
                            /// <summary>
                            /// Comments from Data Base related to the column
                            /// Type: return {Column type}
                            /// </summary>
                            writer.WriteLine("\t\t\t/// <summary>");
                            //if (!string.IsNullOrEmpty(c["COLUMN_COMMENT"].ToString()))
                            //    writer.WriteLine("\t\t\t///" + c["COLUMN_COMMENT"]);
                            writer.WriteLine("\t\t\t///Type: return {0}", c["DATA_TYPE"]);
                            writer.WriteLine("\t\t\t/// </summary>");
                            string propertyName = NamingConvention.SetNamingConvention(c["COLUMN_NAME"].ToString());
                            writer.WriteLine("\t\t\t\tpublic static ColumnDetails {0} = new ColumnDetails()", propertyName);
                            writer.WriteLine("\t\t\t\t{");
                            writer.WriteLine("\t\t\t\t\t Name=\"{0}\",", c["COLUMN_NAME"]);
                            writer.WriteLine("\t\t\t\t\t FullName= \"{0}_{1}\"", t["TABLE_NAME"], c["COLUMN_NAME"]);
                            writer.WriteLine("\t\t\t\t};");
                            if (c["AUTOINCREMENT"].ToString() != "false")
                            {
                                Values += $"@{c["COLUMN_NAME"]}, ";
                                InsertTable += $"{c["COLUMN_NAME"]}, ";
                                UpdateTable += $"{c["COLUMN_NAME"]} = @{c["COLUMN_NAME"]}, ";
                            }
                            if (c["PRIMARY_KEY"].ToString() == "True" && id == "")
                                id = c["COLUMN_NAME"].ToString();
                            allColumnsAlias += t["TABLE_NAME"] + "." + c["COLUMN_NAME"] + " as " + t["TABLE_NAME"] + "_" + c["COLUMN_NAME"] + ", ";
                        });
                        allColumnsAlias = allColumnsAlias.Remove(allColumnsAlias.Length - 2);
                        UpdateTable = UpdateTable.Remove(UpdateTable.Length - 2);
                        InsertTable = InsertTable.Remove(InsertTable.Length - 2);
                        Values = Values.Remove(Values.Length - 2);
                        writer.WriteLine("\t\t\t\tpublic static string allColumnsAlias = \"{0}\";", allColumnsAlias);
                        writer.WriteLine("\t\t\t\tpublic static string UpdateTable = \"{0} where {1} = @{1}\";", UpdateTable, id);
                        writer.WriteLine("\t\t\t\tpublic static string Delete = \"{0} where {1} = @{1}\";", Delete, id);
                        writer.WriteLine("\t\t\t\tpublic static string Select = \"{0} where {1} = @{1}\";", Select, id);
                        writer.WriteLine("\t\t\t\tpublic static string InsertTable = \"{0}){1})\";", InsertTable, Values);
                        writer.WriteLine("\t\t\t}");

                    });
                    writer.WriteLine("\t\t}");
                    #endregion

                    writer.WriteLine("\t}");
                    writer.WriteLine("}");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public string GetTypeString(string mySqlType)
        {
            switch (mySqlType)
            {
                //////Text Data Types
                case "char":
                case "varchar":
                case "tinytext":
                case "text":
                case "blob":
                case "mediumtext":
                case "mediumblob":
                case "longtext":
                case "longblob":
                case "enum":
                    return "string";

                //////Number Data Types
                case "smallint":
                    return "short";
                case "tinyint":
                    return "byte";
                case "bigint":
                case "mediumint":
                    return "long";
                case "float":
                case "double":
                    return "Double";
                case "int":
                case "year":
                    return "int";


                case "decimal":
                    return "decimal";

                case "timestamp":
                    return "Byte[]";

                ////Date data types:
                case "datetime":
                case "date":
                case "time":
                    return "DateTime";

                default:
                    throw new ArgumentOutOfRangeException("MySqlType");
            }
        }
    }
}
