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
using System.IO;
using System.Text.RegularExpressions;

namespace GenerateTemplateUtils2014
{
    public partial class frmMain : Form
    {
        private frmViewData FormViewData;
        public bool AllowExecuteQuery { get; set; }
        private ServerConnect server;
        private ServerConnect serverDB;
        public frmMain()
        {
            InitializeComponent();
        }
        #region Private Function
        private DataTable BindingToServerData(string dbName, string type, string schemaName, string filter)
        {
            string whereFilter = BuildFilter(schemaName, filter);
            string sqlQuery = string.Empty;
            switch (type)
            {
                case "U":
                    lstServerData.ContextMenuStrip = ctxMenuServerData;
                    AllowExecuteQuery = false;
                    break;
                case "P":
                case "FN":
                case "TR":
                    lstServerData.ContextMenuStrip = null;
                    AllowExecuteQuery = true;
                    break;
            }
            rtbOutput.ContextMenuStrip = AllowExecuteQuery ? ctxQueryOutput : null;
            sqlQuery = string.Format(Constants.SQL_Objects, type, whereFilter);
            if (!string.IsNullOrWhiteSpace(sqlQuery))
            {
                //Get data
                DataTable dtSource = Data.ExecuteDataTable(serverDB.Connection, sqlQuery);
                lblTotal.Text = string.Format(Constants.TotalResult, dtSource.Rows.Count, ddlType.Text);
                return dtSource;
            }
            return null;
        }
        private string BuildFilter(string schema, string filter)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(filter))
                sb.Append(Constants.Operator_And).AppendFormat(Constants.Filter_Name, filter);

            if (!string.IsNullOrWhiteSpace(schema))
                sb.Append(Constants.Operator_And).AppendFormat(Constants.Filter_Schema, schema);

            return sb.ToString();
        }
        private void BindingOutput(string id, string type)
        {
            switch (type)
            {
                case "U":
                    TableInfo(id, ddlParamType.SelectedValue);
                    if (ddlGenerateType.SelectedIndex != -1)
                        rtbOutput.Text = GenerateTemplate(ddlGenerateType.SelectedValue.ToString());
                    else
                        rtbOutput.Text = string.Empty;
                    break;
                case "P":
                case "FN":
                case "TR":
                    rtbOutput.Text = ShowComment(id, type);
                    break;
            }
        }
        private void TableInfo(string id, object typeParam)
        {
            //0:ID, Name, 2:Type_Name, Max_Length, 4:Precision, Scale, 6:Is_Identity, Is_Nullable, 8:Index_Name, Index_Desc, 10:Foreign_Name
            DataTable dtOutput = Data.ExecuteDataTable(serverDB.Connection, string.Format(Constants.SQL_Table, id));
            if (dtOutput != null)
            {
                if (typeParam == null)
                {
                    txtParam.Text = string.Empty;
                    return;
                }
                switch (typeParam.ToString())
                {
                    case "SQL":
                        txtParam.Text = OutputSqlParam(dtOutput);
                        break;
                    case "CSharp":
                        txtParam.Text = OutputCSharp(dtOutput);
                        break;
                    case "Property":
                        break;
                    case "Set":
                        break;
                    default:
                        txtParam.Text = OutputSqlParam(dtOutput);
                        break;
                }
                lblParamTotal.Text = dtOutput.Rows.Count + " field.";
            }
        }

        private string OutputSqlParam(DataTable dtOutput)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dtOutput.Rows)
            {
                if (sb.Length > 0)
                    sb.AppendLine();
                sb.AppendFormat("@{0} {1}", dr[1], Utils.TypeSqlServer(dr[2].ToString(), Utils.GetValue<int>(dr[3]), Utils.GetValue<int>(dr[4]), Utils.GetValue<int>(dr[5])));
            }
            return sb.ToString();
        }
        private string OutputCSharp(DataTable dtOutput)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow dr in dtOutput.Rows)
            {
                if (sb.Length > 0)
                    sb.AppendLine();
                sb.AppendFormat("{0}{1} {2}", Utils.SqlToClrType(dr[2].ToString()), Utils.GetValue<bool>(dr[7]) ? "?" : string.Empty, dr[1]);
            }
            return sb.ToString();
        }
        private string ShowComment(string id, string type)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtOutput = Data.ExecuteDataTable(serverDB.Connection, string.Format(Constants.SQL_Comments, id));
            foreach (DataRow dataRow in dtOutput.Rows)
            {
                sb.Append(dataRow[0]);
            }
            return sb.ToString();
        }

        private string GenerateTemplate(string generateType)
        {
            DataTable dtSource = Data.ExecuteDataTable(serverDB.Connection, string.Format(Constants.SQL_Table, lstServerData.SelectedValue));
            string strOutput = string.Empty;
            //Update language
            switch (generateType)
            {
                case "StoreProcedure":
                    strOutput = GenerateStoreProcedure(dtSource);
                    break;
                case "StoreGetByPaging":
                    strOutput = GenerateStoreGetByPaging(dtSource);
                    break;
                case "Entity":
                    strOutput = GenerateClassEntity(dtSource);
                    break;
                case "ADOIpl":
                    strOutput = GenerateADOIplement(dtSource);
                    break;
                case "Model":
                    break;
                case "Controller":
                    strOutput = GenerateController(dtSource);
                    break;
                case "JsController":
                    strOutput = GenerateJSController(dtSource);
                    break;
                case "View":
                    break;
                case "Index":
                    strOutput = GenerateViewIndex(dtSource);
                    break;
                case "Details":
                    break;
                case "AddOrEdit":
                    break;
            }
            return strOutput;
        }

        /// <summary>
        /// Generate Procedure Basic
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        private string GenerateStoreProcedure(DataTable dtSource)
        {
            string author = AppSettings.GetValue("Author");
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });

            var listField = new StringBuilder();
            var columnListInsert = new StringBuilder();
            var paramListUpdate = new StringBuilder();

            var columnListUpdate = new StringBuilder();
            var exceptField = new string[] { "CreatedUserID", "CreatedDate", "UpdatedUserID", "UpdatedDate" };
            var shortName = GetShortName(schemaTable[1]);

            var prefix = schemaTable[1].Split('_')[0];
            var tableNoPrefix = schemaTable[1].Replace(prefix + "_", "");
            string primaryKey = string.Empty;

            string primaryType = string.Empty;
            string createdDate = DateTime.Now.ToString("yyyy-MM-dd");
            var noteX = tableNoPrefix.Replace("_", "");

            var listSetFieldX = new StringBuilder();
            var listFieldX = new StringBuilder();
            var requiredField = string.Empty;

            var whereListFieldChange = new StringBuilder();

            //0:ID, Name, 2:Type_Name, Max_Length, 4:Precision, Scale, 6:Is_Identity, Is_Nullable, 8:Index_Name, Index_Desc, 10:Foreign_Name   
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                DataRow dr = dtSource.Rows[i];
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    primaryType = Utils.GetValue<string>(dr[2]);
                    break;
                }
            }

            // get required field
            if (dtSource.Rows.Count >= 1)
            {
                requiredField = Utils.GetValue<string>(dtSource.Rows[1][1]);
            }

            // build query
            for (int i = 0; i < dtSource.Rows.Count; i++ )
            {
                DataRow dr = dtSource.Rows[i];
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {   
                    continue;
                }
                if (!exceptField.Contains(Utils.GetValue<string>(dr[1])))
                {
                    var fieldType = Utils.GetValue<string>(dr[2]);
                    if (string.Compare(fieldType,"varchar", StringComparison.CurrentCultureIgnoreCase) == 0  || 
                        string.Compare(fieldType, "nvarchar", StringComparison.CurrentCultureIgnoreCase) == 0 ||
                        string.Compare(fieldType, "char", StringComparison.CurrentCultureIgnoreCase) == 0 ||
                        string.Compare(fieldType, "nchar", StringComparison.CurrentCultureIgnoreCase) == 0)
                    {
                        var length = Utils.GetValue<string>(dr[3]);
                        if(length == "-1")
                        {
                            length = "max";
                        }
                        fieldType = string.Format("{0}({1})", fieldType, length);
                    }
                    
                    if (columnListInsert.Length > 0)
                    {
                        columnListInsert.AppendLine().Append("\t\t\t\t\t");
                        listSetFieldX.AppendLine().Append("\t\t\t\t\t");
                        listFieldX.AppendLine().Append("\t\t\t\t\t");
                        whereListFieldChange.AppendLine().Append("\t\t\t\t or ");
                    }
                    columnListInsert.AppendFormat("[{0}]", dr[1]).Append(",");
                    listSetFieldX.AppendFormat("{0}\t\t\t\t\t= x.{1}", dr[1], dr[1]).Append(",");
                    listFieldX.AppendFormat("{0}\t\t{1}", dr[1], fieldType).Append(",");
                    whereListFieldChange.AppendFormat("isnull({0}.{1},'')						<> isnull(x.{2},'')", shortName, dr[1], dr[1]);
                }

                if (listField.Length > 0)
                {
                    listField.AppendLine().Append("\t\t\t\t\t");
                }
                listField.AppendFormat("[{0}]\t\t\t\t\t= {1}.[{2}]", dr[1], shortName, dr[1]);
                if (i + 1 < dtSource.Rows.Count)
                {
                    listField.Append(",");
                }
            }

            var sb = new StringBuilder();
            string txtSpSelect = File.ReadAllText(Path.Combine(AppSettings.GetValue("SQL_Select")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtSpSelect))
            {
               
                txtSpSelect = txtSpSelect
                    .Replace("{Author}", author)
                    .Replace("{prefix}", prefix)
                    .Replace("{TableNoSpace}", schemaTable[1].Replace("_",""))
                    .Replace("{CreatedDate}", createdDate)

                    .Replace("{SchemaName}", schemaTable[0])
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{TableNoPrefix}", tableNoPrefix)

                    .Replace("{TableShortName}", shortName)
                    .Replace("{ListField}", listField.ToString().TrimEnd(','))
                    .Replace("{PrimaryKey}", primaryKey)

                    .Replace("{PrimaryType}", primaryType)
                    .Replace("{NodeX}", noteX)
                    .Replace("{RequiredField}", requiredField) 

                    .Replace("{ListSetFieldX}", listSetFieldX.ToString().TrimEnd(','))
                    .Replace("{ListFieldX}", listFieldX.ToString().TrimEnd(','))
                    .Replace("{ColumnListInsert}", columnListInsert.ToString().TrimEnd(','))

                    .Replace("{ColumnListUpdate}", columnListUpdate.ToString().TrimEnd(','))
                    .Replace("{ParamListUpdate}", paramListUpdate.ToString())
                    .Replace("{WhereListFieldChange}", whereListFieldChange.ToString().Trim().TrimEnd(','));
                sb.AppendLine(txtSpSelect);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get alias of table
        /// act_Activity_Type -> aat
        /// </summary>
        /// <param name="tableName">Table name</param>
        /// <returns></returns>
        private string GetShortName(string tableName)
        {
            string shortName = "";
            var arr = tableName.Split('_').Where(s=> !string.IsNullOrEmpty(s));
            foreach (var s in arr)
            {
                if (s.Length > 1)
                {
                    shortName += s.Substring(0, 1);
                }
                else
                    shortName += s;
            }
            return shortName.ToLower();
        }

        private string GenerateStoreGetByPaging(DataTable dtSource)
        {
            string author = AppSettings.GetValue("Author");
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });

            var listField = new StringBuilder();
            string primaryKey = string.Empty;
            string primaryType = string.Empty;
            string createdDate = DateTime.Now.ToString("yyyyMMdd");

            //0:ID, Name, 2:Type_Name, Max_Length, 4:Precision, Scale, 6:Is_Identity, Is_Nullable, 8:Index_Name, Index_Desc, 10:Foreign_Name
            foreach (DataRow dr in dtSource.Rows)
            {
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    primaryType = Utils.GetValue<string>(dr[2]);
                    break;
                }
            }

            var sb = new StringBuilder();
            string txtSpSelect = File.ReadAllText(Path.Combine(AppSettings.GetValue("SQL_GetByPaging")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtSpSelect))
            {
                txtSpSelect = txtSpSelect
                    .Replace("{Author}", author)
                    .Replace("{CreatedDate}", createdDate)
                    .Replace("{SchemaName}", schemaTable[0])
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{PrimaryKey}", primaryKey);
                sb.AppendLine(txtSpSelect);
            }
            return sb.ToString();
        }

        private string GenerateViewIndex(DataTable dtSource)
        {
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });
            string primaryKey = string.Empty;
            const string templateGridColumn = "new GridColumn { Field = \"{FieldName}\", Title = \"{FieldName}\", Position = {Index}, Visiable = true, Width = 0, Template = \"<span class='pre'>#=kendoNullToString({FieldName})#</span>\" }";

            var sbListField = new StringBuilder();
            int index = 1;
            foreach (DataRow dr in dtSource.Rows)
            {
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    continue;
                }
                if (sbListField.Length > 0)
                    sbListField.Append(",").AppendLine().Append("\t\t").Append(templateGridColumn.Replace("{FieldName}", Utils.GetValue<string>(dr[1])).Replace("{Index}", index.ToString()));
                else
                    sbListField.Append(templateGridColumn.Replace("{FieldName}", Utils.GetValue<string>(dr[1])).Replace("{Index}", index.ToString()));
                index++;
                if (index > 5)
                    break;
            }

            var sb = new StringBuilder();
            string txtViewIndex = File.ReadAllText(Path.Combine(AppSettings.GetValue("View_Index")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtViewIndex))
            {
                txtViewIndex = txtViewIndex
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{TableNameLower}", Char.ToLower(schemaTable[1][0]) + schemaTable[1].Substring(1))
                    .Replace("{PrimaryKey}", primaryKey)
                    .Replace("{ListField}", sbListField.ToString());
                sb.AppendLine(txtViewIndex);
            }
            return sb.ToString();

        }
        public string GenerateClassEntity(DataTable dtSource)
        {
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });
            const string templateProperty = "public {FieldType} {FieldName} {get; set;}";
            var sbListField = new StringBuilder();
            string attributeName = string.Empty;
            foreach (DataRow dr in dtSource.Rows)
            {
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    attributeName = "[Key]";
                }
                else if (Utils.GetValue<bool>(dr[7]) == false)
                {
                    attributeName = "[Required]";
                }
                if (sbListField.Length > 0)
                {
                    if (!string.IsNullOrWhiteSpace(attributeName))
                        sbListField.AppendLine().Append("\t" + attributeName);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(attributeName))
                        sbListField.Append(attributeName);
                }
                sbListField.AppendLine().Append("\t").Append(templateProperty.Replace("{FieldName}", dr[1].ToString()).Replace("{FieldType}", Utils.SqlToClrType(dr[2].ToString(), Utils.GetValue<bool>(dr[7]))));
                attributeName = string.Empty;
            }

            var sb = new StringBuilder();
            string txtClassEntity = File.ReadAllText(Path.Combine(AppSettings.GetValue("Class_Entity")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtClassEntity))
            {
                txtClassEntity = txtClassEntity
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{ListField}", sbListField.ToString());
                sb.AppendLine(txtClassEntity);
            }
            return sb.ToString();
        }
        private string GenerateController(DataTable dtSource)
        {
            var arrFilterName = new string[] { "Name", "Title", "Subject", "Description" };
            var exceptField = new string[] { "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" };
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });
            const string templateProperty = "{FieldName} = q.{FieldName},";
            string primaryKey = string.Empty, primaryType = string.Empty;
            string filterName = string.Empty;
            var sbListField = new StringBuilder();
            foreach (DataRow dr in dtSource.Rows)
            {
                if (string.IsNullOrWhiteSpace(filterName) && arrFilterName.Contains(Utils.GetValue<string>(dr[1])))
                    filterName = Utils.GetValue<string>(dr[1]);
                if(exceptField.Contains(Utils.GetValue<string>(dr[1])))
                    continue;
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    primaryType = Utils.GetValue<string>(Utils.SqlToClrType(dr[2].ToString(), Utils.GetValue<bool>(dr[7])));
                }

                if (sbListField.Length > 0)
                {
                    sbListField.AppendLine().Append("\t\t\t").Append(templateProperty.Replace("{FieldName}", dr[1].ToString()));
                }
                else
                {
                    sbListField.Append(templateProperty.Replace("{FieldName}", dr[1].ToString()));
                }
            }

            var sb = new StringBuilder();
            string txtClassEntity = File.ReadAllText(Path.Combine(AppSettings.GetValue("Web_Controller")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtClassEntity))
            {
                txtClassEntity = txtClassEntity
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{PrimaryKey}", primaryKey)
                    .Replace("{PrimaryKeyLower}", Char.ToLower(primaryKey[0]) + primaryKey.Substring(1))
                    .Replace("{PrimaryType}", primaryType)
                    .Replace("{FilterName}", filterName)
                    .Replace("{ListField}", sbListField.ToString());
                sb.AppendLine(txtClassEntity);
            }
            return sb.ToString();
        }
        private string GenerateADOIplement(DataTable dtSource)
        {
            var exceptField = new string[] { "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate" };
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });
            const string templateParam = "param.Add(\"@{FieldName}\", itemInfo.{FieldName});";
            const string templateGet = "{FieldName} = item.{FieldName},";
            string primaryKey = string.Empty, primaryType = string.Empty, primaryDbType = string.Empty;
            var sbListFieldParam = new StringBuilder();
            var sbListFieldGet = new StringBuilder();
            foreach (DataRow dr in dtSource.Rows)
            {
                if (exceptField.Contains(Utils.GetValue<string>(dr[1])))
                    continue;
                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    primaryType = Utils.SqlToClrType(dr[2].ToString(), Utils.GetValue<bool>(dr[7]));
                    primaryDbType = Utils.SqlToDbType(dr[2].ToString());
                    continue;
                }

                if (sbListFieldGet.Length > 0)
                {
                    sbListFieldGet.AppendLine().Append("\t").Append(templateGet.Replace("{FieldName}", dr[1].ToString()));
                }
                else
                {
                    sbListFieldGet.Append(templateGet.Replace("{FieldName}", dr[1].ToString()));
                }

                if (sbListFieldParam.Length > 0)
                {
                    sbListFieldParam.AppendLine().Append("\t").Append(templateParam.Replace("{FieldName}", dr[1].ToString()));
                }
                else
                {
                    sbListFieldParam.Append(templateParam.Replace("{FieldName}", dr[1].ToString()));
                }
            }

            var sb = new StringBuilder();
            string txtClassEntity = File.ReadAllText(Path.Combine(AppSettings.GetValue("ADO_Implement")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtClassEntity))
            {
                txtClassEntity = txtClassEntity
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{TableNameLower}", Char.ToLower(schemaTable[1][0]) + schemaTable[1].Substring(1))
                    .Replace("{PrimaryKey}", primaryKey)
                    .Replace("{PrimaryType}", primaryType)
                    .Replace("{PrimaryDbType}", primaryDbType)
                    .Replace("{ListFieldParam}", sbListFieldParam.ToString())
                    .Replace("{ListFieldGet}", sbListFieldGet.ToString());
                sb.AppendLine(txtClassEntity);
            }
            return sb.ToString();
        }
        private string GenerateJSController(DataTable dtSource)
        {
            string[] schemaTable = lstServerData.Text.Split(new char[] { '.' });
            string primaryKey = string.Empty;
            StringBuilder sbListField = new StringBuilder();
            foreach (DataRow dr in dtSource.Rows)
            {

                if (!string.IsNullOrWhiteSpace(Utils.GetValue<string>(dr[8])) && Utils.GetValue<string>(dr[9]).Equals("CLUSTERED"))
                {
                    primaryKey = Utils.GetValue<string>(dr[1]);
                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            string txtClassEntity = File.ReadAllText(Path.Combine(AppSettings.GetValue("JS_List_Controller")), Encoding.UTF8);
            if (!string.IsNullOrWhiteSpace(txtClassEntity))
            {
                txtClassEntity = txtClassEntity
                    .Replace("{TableName}", schemaTable[1])
                    .Replace("{TableNameLower}", Char.ToLower(schemaTable[1][0]) + schemaTable[1].Substring(1))
                    .Replace("{PrimaryKey}", primaryKey)
                    .Replace("{PrimaryKeyLower}", Char.ToLower(primaryKey[0]) + primaryKey.Substring(1));
                sb.AppendLine(txtClassEntity);
            }
            return sb.ToString();
        }
        private void CanChooseServer(bool enable)
        {
            txtServer.Enabled = txtUid.Enabled = txtPwd.Enabled = chkIntegrated.Enabled = enable;
            ddlDatabase.Enabled = ddlSchema.Enabled = ddlType.Enabled = lstServerData.Enabled = txtFilter.Enabled = !enable;
        }
        #endregion
        #region Event Function
        #region Event Left Form
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == Constants.Connect)
            {
                btnConnect.Text = Constants.ReConnect;
                CanChooseServer(false);

                server = new ServerConnect
                {
                    ServerName = txtServer.Text,
                    Uid = txtUid.Text,
                    Pwd = txtPwd.Text,
                    Integreated = chkIntegrated.Checked
                };

                var connection = server.Connection;
                ddlDatabase.BindingListControl(Data.ExecuteDataTable(connection, Constants.SQL_SelectDB), Constants.Name, Constants.ID);
                ddlType.BindingListControl(
                    new Dictionary<string, string>
                        {
                            {"U","Table"},
                            {"P","Store Procedure"},
                            {"FN","Function"},
                            {"TR","Trigger"}
                        }.ToList(),
                        Constants.Value, Constants.Key);

                ddlParamType.BindingListControl(
                    new Dictionary<string, string>
                    {
                        {"", ""},
                        {"SQL", "Sql Type"},
                        {"CSharp", "CSharp Type"},
                        {"Property", "Property"},
                        {"Set", "Set value"}
                    }.ToList(),
                    Constants.Value, Constants.Key);

                ddlGenerateType.BindingListControl(
                    new Dictionary<string, string>
                    {
                        {"", ""},
                        {"StoreProcedure", "Store Procedure"},
                        {"StoreGetByPaging", "Store Get By Paging"},
                        {"Entity", "Entity"},
                        {"ADOIpl", "ADO Implement"},
                        {"Model", "Model"},
                        {"Controller", "Controller"},
                        {"JsController", "Javascript Controller"},
                        {"View", "View"},
                        {"Index", "View Index"},
                        {"Details", "View Details"},
                        {"AddOrEdit", "View Add/Edit"}
                    }.ToList(),
                    Constants.Value, Constants.Key);
            }
            else
            {
                if (server != null)
                    server.Close();
                btnConnect.Text = Constants.Connect;
                CanChooseServer(true);
            }
        }

        private void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDatabase.SelectedIndex != -1)
            {
                //Reset selected index of type
                ddlType.SelectedIndex = -1;
                serverDB = new ServerConnect
                {
                    ServerName = txtServer.Text,
                    Uid = txtUid.Text,
                    Pwd = txtPwd.Text,
                    Integreated = chkIntegrated.Checked,
                    Database = ddlDatabase.Text
                };
                ddlSchema.BindingListControl(Data.ExecuteDataTable(serverDB.Connection, Constants.SQL_Schemas), Constants.Name, Constants.ID);
                lstServerData.DataSource = null; //Clear server data
            }
        }

        private void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex != -1)
            {
                //Binding to lstServerData
                DataTable dtSource = BindingToServerData(ddlDatabase.Text, ddlType.SelectedValue.ToString(), ddlSchema.Text, txtFilter.Text);
                lstServerData.BindingListControl(dtSource, Constants.Name, Constants.ID);
                ddlGenerateType.Enabled = ddlParamType.Enabled = ddlType.SelectedValue.ToString().Equals("U");
            }
        }

        private void ddlSchema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSchema.SelectedIndex != -1 && ddlType.SelectedIndex != -1)
            {
                DataTable dtSource = BindingToServerData(ddlDatabase.Text, ddlType.SelectedValue.ToString(), ddlSchema.Text, txtFilter.Text);
                lstServerData.BindingListControl(dtSource, Constants.Name, Constants.ID);
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            //Binding to lstServerData
            if (ddlDatabase.SelectedIndex != -1 && ddlType.SelectedIndex != -1)
            {
                DataTable dtSource = BindingToServerData(ddlDatabase.Text, ddlType.SelectedValue.ToString(), ddlSchema.Text, txtFilter.Text);
                lstServerData.BindingListControl(dtSource, Constants.Name, Constants.ID);
            }
        }

        private void lstServerData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstServerData.SelectedIndex != -1 && ddlType.SelectedIndex != -1)
            {
                BindingOutput(lstServerData.SelectedValue.ToString(), ddlType.SelectedValue.ToString());
            }
        }
        #endregion

        #region Event Right Form
        private void ddlParamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlParamType.SelectedIndex != -1 && lstServerData.SelectedIndex != -1 && ddlType.SelectedValue == "U")
            {
                TableInfo(lstServerData.SelectedValue.ToString(), ddlParamType.SelectedValue);
            }
        }

        private void ddlGenerateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGenerateType.SelectedIndex != -1 && lstServerData.SelectedIndex != -1)
            {
                rtbOutput.Text = GenerateTemplate(ddlGenerateType.SelectedValue.ToString());
            }
        }
        #endregion

        #region Event Menu Strip
        private void viewDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstServerData.SelectedIndex != -1)
            {
                FormViewData = new frmViewData(serverDB, lstServerData.DataSource as DataTable, string.Format(Constants.SQL_SelectTop, lstServerData.Text));
                FormViewData.ShowDialog();
            }
        }

        private void viewInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstServerData.SelectedIndex != -1)
            {
                FormViewData = new frmViewData(serverDB, lstServerData.DataSource as DataTable, string.Format(Constants.SQL_Table, lstServerData.SelectedValue));
                FormViewData.ShowDialog();
            }
        }

        private void dBBCRESESTEDToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbOutput.TextLength > 0)
            {
                string query = rtbOutput.SelectionLength == 0 ? rtbOutput.Text.Trim() : rtbOutput.SelectedText.Trim();
                if (Utils.IsQuerySelect(query))
                {
                    FormViewData = new frmViewData(serverDB, lstServerData.DataSource as DataTable, query);
                    FormViewData.ShowDialog();
                }
                else
                    MessageBox.Show(Data.ExecuteNonQuery(serverDB.Connection, query));
            }
        }

        private void numberConnectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Event Form
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Constants.Exit_Confirm, Constants.Exit_Confirm_Title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (server != null)
                    server.Close();
                if (serverDB != null)
                    serverDB.Close();
            }
            else
                e.Cancel = true;

        }
        #endregion

        private void lstServerData_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

        private void lstServerData_KeyUp(object sender, KeyEventArgs e)
        {
            if (lstServerData.SelectedIndex != -1 && e.KeyCode == Keys.Delete)
            {
                if (ddlType.SelectedValue.ToString().Equals("U"))
                {
                    if (MessageBox.Show("Are you sure delete " + lstServerData.Text + " ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show(Data.ExecuteNonQuery(serverDB.Connection, "DROP TABLE " + lstServerData.Text));
                        //lstServerData.Items.Remove(lstServerData.SelectedItem);
                    }
                }
                else if (ddlType.SelectedValue.ToString().Equals("P"))
                {
                    if (MessageBox.Show("Are you sure delete " + lstServerData.Text + " ?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MessageBox.Show(Data.ExecuteNonQuery(serverDB.Connection, "DROP PROC " + lstServerData.Text));
                        //lstServerData.Items.Remove(lstServerData.SelectedItem);
                    }
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
