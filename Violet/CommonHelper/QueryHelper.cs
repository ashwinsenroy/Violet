using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Violet.CommonHelper
{
    public class QueryHelper
    {
        public static string CreateInsertQuery(int NoOfProperties, string Tablename, Dictionary<string, object> dictionary)
        {
            string[] columns = new string[NoOfProperties];
            int i = 0;
            foreach (var item in dictionary)
            {
                columns[i] = item.Key;
                i++;
            }

            string Columns = string.Join(",", columns);
            string[] values = new string[NoOfProperties];
            for (int x = 0; x < values.Length; x++)
            {
                string val = columns[x].ToString();
                val = string.Concat("@", val);
                values[x] = val;
            }
            string Values = string.Join(",", values);
            string Query = $"INSERT INTO {Tablename} ({Columns}) VALUES ({Values});";
            return Query;

        }































































    }
}