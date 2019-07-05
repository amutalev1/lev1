using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.DBMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = new CmdOptions();
                CommandLine.Parser.Default.ParseArguments(args, options);
                IDbMapper mapper = null;
                switch (options.DataProvider)
                {
                    case "System.Data.SqlClient":
                        mapper = new DBMapperMSSql(options.ConStr);
                        break;
                    case "MySql.Data.MySqlClient":
                        mapper = new DbMapperMySql(options.ConStr);
                        break;
                    case "System.Data.SQLite":
                        mapper = new DbMapperSqlite(options.ConStr);
                        break;
                    default:
                        break;
                }

                string targetFile = Path.Combine(options.TargetFolder, "DbContent.cs");
                mapper.MapDataBase(targetFile, options.Namespace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
