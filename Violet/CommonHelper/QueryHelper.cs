using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Violet.CommonHelper
{
    public class QueryHelper
    {
        public static string CreateInsertQuery(string Tablename, string[] Parameters)
        {
            Parameters = Parameters.Select(Parameter => "@" + Parameter).ToArray();
            string Values = string.Join(",", Parameters);
            string Query = $"INSERT INTO {Tablename} VALUES ( {Values} );";
            return Query;

        }































































    }
}