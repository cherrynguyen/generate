using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
namespace GenerateTemplateUtils2014
{
    public partial class frmViewData : Form
    {
        private ServerConnect serverDB { get; set; }
        public frmViewData()
        {
            InitializeComponent();
        }
        public frmViewData(ServerConnect server, DataTable dtTable, string sqlQuery)
            : this()
        {
            serverDB = server;
            LoadData(sqlQuery);
            ddlTables.BindingListControl(dtTable, Constants.Name, Constants.ID);
            ddlTables.SelectedIndexChanged += ddlTables_SelectedIndexChanged;
        }

        private void LoadData(string sqlQuery)
        {
            dgvTableData.DataSource = Data.ExecuteDataTable(serverDB.Connection, sqlQuery);
        }

        private void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTables.SelectedIndex != -1)
            {
                LoadData(string.Format(Constants.SQL_SelectTop, ddlTables.Text));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmViewData_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serverDB != null)
            {
                ddlTables.SelectedIndexChanged -= ddlTables_SelectedIndexChanged;
                serverDB = null;
            }
        }
    }
}
