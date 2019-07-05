using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seldat.DBMapper
{
    public static class NamingConvention
    {
        public static string SetNamingConvention(string columnName)
        {
            int index = 0;
            var columnProperty = new StringBuilder(columnName.ToLower());
            while (index > -1)
            {
                index = columnProperty.ToString().IndexOf("_");
                if (index != -1)
                {
                    columnProperty.Remove(index, 1);//remove the "_"
                    columnProperty.Replace(columnProperty.ToString()[index], Char.ToUpper(columnProperty.ToString()[index]), index, 1);//make the '_' followed char to upper
                }
            }
            return Char.ToUpper(columnProperty.ToString()[0]) + columnProperty.ToString().Substring(1);
        }
    }
}
