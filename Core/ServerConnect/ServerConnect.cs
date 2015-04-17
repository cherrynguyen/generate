using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ServerConnect
    {
        private SqlConnection _connection;
        #region Property
        public string ServerName { get; set; }
        public string Uid { get; set; }
        public string Pwd { get; set; }
        public string Database { get; set; }
        public bool Integreated { get; set; }
        protected string ServerDB
        {
            get
            {
                return string.IsNullOrWhiteSpace(Database) ? string.Empty : string.Format(Constants.Server_Database, Database);
            }
        }
        public SqlConnection Connection
        {
            get
            {
                if (ServerValid)
                    return new SqlConnection(this.ToString());
                return null;
            }
        }

        #endregion
        #region Public Function
        #region Get Data
        //Get Table list
        //Get Procedure list
        //Get Function list
        //Get Trigger list
        //Get data of Table
        //Get number of connection
        //Get activity manager
        #endregion
        #region Execute
        //Generate create/alter table
        //Execute alter procedure/function/trigger
        //Delete Table/Procedure/Function/Trigger
        //DBBC Reseted
        #endregion
        #endregion
        #region Private Function
        private bool ServerValid
        {
            get
            {
                return Integreated ?
                    !string.IsNullOrWhiteSpace(ServerName) :
                    !string.IsNullOrWhiteSpace(ServerName) && !string.IsNullOrWhiteSpace(Uid) && !string.IsNullOrWhiteSpace(Pwd);
            }
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            if (!ServerValid)
                return string.Empty;

            return this.Integreated ?
                string.Format(Constants.Server_Integrated, ServerName, ServerDB) :
                string.Format(Constants.Server_Connect, ServerName, Uid, Pwd, ServerDB);
        }
        #endregion

        public void Close()
        {
            ServerName = Uid = Pwd = string.Empty;

            if (this.Connection != null && this.Connection.State != ConnectionState.Closed)
            {
                this.Connection.Close();
                this.Connection.Dispose();
            }
        }
    }
}
