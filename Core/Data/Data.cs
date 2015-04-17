using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Data
    {
        public static DataTable ExecuteDataTable(string strConn, string sqlQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (SqlException sqlException)
            {
                //Log error
                return null;
            }
        }
        public static DataTable ExecuteDataTable(SqlConnection connection, string sqlQuery)
        {
            if (connection == null)
                return null;
            try
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (SqlException sqlException)
            {
                //Log error
                return null;
            }
        }

        public static string ExecuteNonQuery(string strConn, string sqlQuery)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConn))
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection) { CommandType = CommandType.Text })
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        command.ExecuteNonQuery();
                        return "Command execute success.";
                    }
                }
            }
            catch (SqlException sqlException)
            {
                //Log error
                return "Command execute error: " + sqlException.Message;
            }
        }
        public static string ExecuteNonQuery(SqlConnection connection, string sqlQuery)
        {
            if (connection == null)
                return "Connection was not initialize.";
            try
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection) { CommandType = CommandType.Text })
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    command.ExecuteNonQuery();
                    return "Command execute success.";
                }
            }
            catch (SqlException sqlException)
            {
                //Log error
                return "Command execute error: " + sqlException.Message;
            }
        }
    }
}
