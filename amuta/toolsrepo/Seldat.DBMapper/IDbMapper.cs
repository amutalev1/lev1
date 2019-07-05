using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Seldat.DBMapper
{
    interface IDbMapper
    {
        DbConnection Connection { get; set; }

        void MapDataBase(string outputPath, string TargetNameSpace);
    }
}
        






