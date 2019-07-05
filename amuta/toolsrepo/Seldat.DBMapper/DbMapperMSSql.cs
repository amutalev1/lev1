using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.DBMapper
{
    public class DBMapperMSSql : IDbMapper
    {
        public DbConnection Connection { get; set; }

        public DBMapperMSSql(string conStr)
        {
            Connection = new SqlConnection(conStr);
        }

        public void MapDataBase(string outputPath, string TargetNameSpace)
        {
            Connection.Open();

            try
            {
                using (StreamWriter writer= new StreamWriter(outputPath))
                {
                    writer.WriteLine(string.Format("namespace {0}{{", TargetNameSpace));
                    writer.WriteLine();
                    writer.WriteLine("\tpublic static class DbContent{");

                    #region Tables
                    var columnsSchema = Connection.GetSchema("columns");
                    var tables = columnsSchema.AsEnumerable().GroupBy(t => t["TABLE_NAME"]);

                    writer.WriteLine("\t\tpublic static class Tables{");

                    tables.ToList().ForEach(table =>
                    {
                        //TODO add samary before
                        writer.WriteLine("\t\t\tpublic static class {0}{{", table.Key);
                        writer.WriteLine("\t\t\tpublic static string TableName = \"{0}\";", table.Key);
                        table.ToList().ForEach(row =>
                        {
                            writer.WriteLine("\t\t\t\t/// <summary>");
                            writer.WriteLine("\t\t\t\t///Type: {0}", row["DATA_TYPE"]);
                            writer.WriteLine("\t\t\t\t/// </summary>");
                            
                            //string propertyName = NamingConvention.SetNamingConvention(row["COLUMN_NAME"].ToString());
                            writer.WriteLine("\t\t\t\tpublic static string {0} = \"{1}\";","", row["COLUMN_NAME"]);
                        });
                        writer.WriteLine("\t\t\t}"); // end table class
                    });

                    writer.WriteLine("\t\t}"); //end class tables
                    #endregion

                    #region Procedures&function
                    var schemaProcedures = Connection.GetSchema("Procedures");
                    var procedureParametersSchema = Connection.GetSchema("ProcedureParameters");

                    var routines = schemaProcedures.AsEnumerable().GroupBy(proc => proc["ROUTINE_NAME"]);
                    var procParameters = procedureParametersSchema.AsEnumerable().GroupBy(p => p["SPECIFIC_NAME"]);

                    routines.ToList().ForEach(routine =>
                    {
                        writer.WriteLine(string.Format("\t\tpublic static class {0}{{", routine.Key + "s"));
                        routine.ToList().ForEach(procedure =>
                        {
                            writer.WriteLine("\t\t\t/// <summary>");
                            writer.WriteLine("\t\t\t/// parameters:");
                            var parameters = procParameters.Where(p => p.Key.ToString() == procedure["SPECIFIC_NAME"].ToString()).FirstOrDefault();
                            parameters.ToList().ForEach(parameter =>
                              {
                                  writer.WriteLine(string.Format("\t\t\t///{0}{1}({2})", parameter["DATA_TYPE"], parameter["PARAMETER_NAME"], parameter["PARAMETER_MODE"]));
                              });
                            writer.WriteLine("\t\t\t/// </summary>");
                            writer.WriteLine("\t\t\tpublic static string {0} = \"{0}\";", procedure["SPECIFIC_NAME"]);
                        });
                        writer.WriteLine("\t\t}"); // end procedure class
                    });
                    #endregion

                    #region views
                    var schemaviews = Connection.GetSchema("views");
                    writer.WriteLine("\t\tpublic static class Views{");

                    foreach (DataRow view in schemaviews.Rows)
                    {
                        writer.WriteLine("\t\t\tpublic static string {0} = \"{0}\";", view["TABLE_NAME"]);

                    };
                    writer.WriteLine("\t\t}"); //end class views
                    #endregion

                    writer.WriteLine("\t}"); //end class DbContent
                    writer.WriteLine("}"); //end namespace

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

       
    }
}




