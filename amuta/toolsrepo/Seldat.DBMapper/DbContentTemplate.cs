using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.DBMapper
{
    public static class DbContentTemplate
    {
        public static class Tables
        {
            /// <summary>
            /// Comments from Data Base related to the table here 
            /// </summary>
            public static class SpecificTable1
            {
                /// <summary>
                /// Comments from Data Base related to the column
                /// Type: {Column type}
                /// </summary>
                public static string Id = "Id";
                /// <summary>
                /// Comments from Data Base related to the column
                /// Type: {Column type}
                /// </summary>
                public static string Username = "Username";

            }
        }

        public static class Views
        {
        }

        public static class StoredProcedures
        {
        }
    }
}
