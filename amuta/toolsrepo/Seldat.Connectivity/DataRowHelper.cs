using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.Connectivity
{
    public class DataRowHelper
    {
        public static event Action<String> OnLogMessage;

        private static bool ShouldLog { get { return OnLogMessage != null; } }
        private static void LogMessage(String message)
        {
            if (ShouldLog)
                OnLogMessage(message);
        }

        public static T GetValue<T>(DataRow row, string fieldName, object defaultValue = null)
        {
            if (row == null) return default(T);
            if (!row.Table.Columns.Contains(fieldName))
            {// if this message appears in logs, someone should fix the code. It is problem
                LogMessage($"Column {fieldName} doesn't exist.{Environment.NewLine}Stack trace: { new System.Diagnostics.StackTrace().ToString() }");
                return defaultValue == null ? default(T) : (T)defaultValue;
            }
            if (row[fieldName] == DBNull.Value)
                return defaultValue == null ? default(T) : (T)defaultValue;

            return row.Field<T>(fieldName);
        }

        public static T ParseEnum<T>(string value) where T : struct
        {
            T res;
            if(Enum.TryParse(value, true, out res))
                return res;

            // if this message appears in logs, someone should fix the code. It is problem
            LogMessage($"Value {value} cannot be parsed to enum of type { typeof(T).ToString() }");
            return default(T);
        }
    }
}
