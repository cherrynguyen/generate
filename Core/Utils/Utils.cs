using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Utils
    {
        public static string SqlToClrType(string sqlType)
        {
            Dictionary<string, string> dicSqlToClr = new Dictionary<string, string>
            {
                {"varbinary", "byte[]"},
                {"binary", "byte[]"},
                {"varchar", "string"},
                {"char", "string"},
                {"nvarchar", "string"},
                {"nchar", "string"},
                {"text", "string"},
                {"ntext", "string"},
                {"uniqueidentifier", "Guid"},
                {"rowversion", "byte[]"},
                {"bit", "bool"},
                {"tinyint", "byte"},
                {"smallint", "Int16"},
                {"int", "int"},
                {"bigint", "Int64"},
                {"smallmoney", "decimal"},
                {"money", "decimal"},
                {"numeric", "decimal"},
                {"decimal", "decimal"},
                {"real", "single"},
                {"float", "double"},
                {"smalldatetime", "DateTime"},
                {"date", "Date"},
                {"datetime", "DateTime"},
                {"datetime2", "DateTime"},
                {"time", "TimeSpan"},
                {"sql_variant", ""}
            };
            if (dicSqlToClr.ContainsKey(sqlType))
                return dicSqlToClr[sqlType];
            return sqlType;
        }
        public static string SqlToClrType(string sqlType, bool isRequired)
        {
            string type = SqlToClrType(sqlType);
            if (isRequired && type != "string")
                return type + "?";
            return type;
        }
        public static string SqlToDbType(string sqlType)
        {
            Dictionary<string, string> dicSqlToSqlDbType = new Dictionary<string, string>
            {
                {"varbinary", "DbType.Binary"},
                {"binary", "DbType.Binary"},
                {"rowversion", "DbType.Binary"},
                {"varchar", "DbType.String"},
                {"char", "DbType.String"},
                {"nvarchar", "DbType.String"},
                {"nchar", "DbType.String"},
                {"text", "DbType.String"},
                {"ntext", "DbType.String"},
                {"bit", "DbType.Bool"},
                {"byte", "DbType.Byte"},
                {"smallint", "DbType.Int16"},
                {"int", "DbType.Int32"},
                {"bigint", "DbType.Int64"},
                {"smallmoney", "DbType.Decimal"},
                {"money", "DbType.Decimal"},
                {"numeric", "DbType.Decimal"},
                {"decimal", "DbType.Decimal"},
                {"real", "DbType.Single"},
                {"float", "DbType.Double"},
                {"smalldatetime", "DbType.DateTime"},
                {"date", "DbType.Date"},
                {"datetime", "DbType.DateTime"},
                {"datetime2", "DbType.DateTime"},
                {"uniqueidentifier", "DbType.Guid"},
            };
            if (dicSqlToSqlDbType.ContainsKey(sqlType))
                return dicSqlToSqlDbType[sqlType];
            return sqlType;
        }
        public static string TypeSqlServer(string dataType, int iMaxLength, int iPrecision, int iScale)
        {
            switch (dataType)
            {
                case "char":
                case "nchar":
                case "varchar":
                case "nvarchar":
                case "binary":
                case "varbinary":
                    return string.Format(Constants.Format_SqlString, dataType, iMaxLength == -1 ? "MAX" : iMaxLength.ToString());
                case "decimal":
                case "numeric":
                    return string.Format(Constants.Format_NumberPrecision, dataType, iPrecision, iScale);
                default:
                    return dataType;
            }
        }

        public static T GetValue<T>(object value)
        {
            T result = default(T);
            try
            {
                result = (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        public static bool IsQuerySelect(string query)
        {
            string[] strArr = { "select", "exec", "sp_helptext" };
            foreach (string str in strArr)
                if (query.Trim().StartsWith(str, StringComparison.CurrentCultureIgnoreCase))
                    return true;
            return false;
        }
    }
}
