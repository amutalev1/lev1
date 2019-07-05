using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Connectivity.ClientFactory
{
    public sealed class MySqlCustomClientFactory : DbProviderFactory
    {
        public static readonly MySqlCustomClientFactory Instance = new MySqlCustomClientFactory();

        public override DbCommand CreateCommand()
        {
            return MySqlClientFactory.Instance.CreateCommand();
        }

        public override DbConnection CreateConnection()
        {
            return MySqlClientFactory.Instance.CreateConnection();
        }

        public override DbParameter CreateParameter()
        {
            return MySqlClientFactory.Instance.CreateParameter();
        }

        public override DbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        #region Private CTOR
        private MySqlCustomClientFactory() {; }
        #endregion
    }
}
