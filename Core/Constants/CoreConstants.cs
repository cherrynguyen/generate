using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    /// <summary>
    /// Core Constant
    /// </summary>
    partial class Constants
    {
        public const string Server_Connect = "Server={0};Uid={1};Pwd={2}{3}";
        public const string Server_Integrated = "Server={0};Integrated Security=true{1}";
        public const string Server_Database = ";Database={0}";
        //SqlQuery
        public const string SQL_SelectDB = "SELECT dbid AS ID, Name FROM SysDatabases WHERE dbid > 4 ORDER BY Name";
        public const string SQL_Schemas = "SELECT  0 As ID, '' AS Name Union SELECT schema_id as ID, Name FROM sys.schemas WHERE principal_id=1 ORDER BY name"; //schema_id
        public const string SQL_Objects = "SELECT object_id as ID, schema_name(schema_id) + '.'+ name AS Name FROM sys.objects WHERE type='{0}' {1} ORDER BY schema_name(schema_id),name";
        public const string SQL_Comments = "SELECT Text FROM SysComments WHERE id={0}";
        public const string SQL_Table = "SELECT c.object_id AS ID, c.Name, type_name(c.system_type_id) AS Type_Name, c.Max_Length, c.[Precision], c.Scale"
                                        + ", c.is_identity AS Is_Identity, c.is_nullable AS Is_Nullable"
                                        + ", i.name AS Index_Name, i.type_desc AS Index_Desc, object_name(f.constraint_object_id) AS Foreign_Name"
                                        + " FROM sys.columns c"
                                        + " LEFT JOIN sys.index_columns ic on ic.object_id = c.object_id and c.column_id = ic.column_id"
                                        + " LEFT JOIN sys.indexes i on c.object_id=i.object_id and i.index_id=ic.index_id"
                                        + " LEFT JOIN sys.foreign_key_columns f on c.object_id = f.parent_object_id and c.column_id = f.parent_column_id"
                                        + " WHERE c.object_id={0}";
        public const string SQL_SelectTop = "SELECT TOP 3000 * FROM {0}";

        //Sql Filter
        public const string Filter_Name = "(name LIKE '%{0}%' OR schema_name(schema_id) + '.' + name like '%{0}%')";
        public const string Filter_Schema = "schema_name(schema_id) = '{0}'";
        public const string Operator_And = " AND ";
        public const string Operator_Or = " Or ";
    }
}
