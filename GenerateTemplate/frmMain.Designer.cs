namespace GenerateTemplateUtils2014
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ddlSchema = new System.Windows.Forms.ComboBox();
            this.lstServerData = new System.Windows.Forms.ListBox();
            this.ddlType = new System.Windows.Forms.ComboBox();
            this.chkIntegrated = new System.Windows.Forms.CheckBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ddlDatabase = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lblParamTotal = new System.Windows.Forms.Label();
            this.ddlParamType = new System.Windows.Forms.ComboBox();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.ddlGenerateType = new System.Windows.Forms.ComboBox();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.ctxMenuServerData = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dBBCRESESTEDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxQueryOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.executeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numberConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.ctxMenuServerData.SuspendLayout();
            this.ctxQueryOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 450);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(973, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(973, 450);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ddlSchema);
            this.groupBox1.Controls.Add(this.lstServerData);
            this.groupBox1.Controls.Add(this.ddlType);
            this.groupBox1.Controls.Add(this.chkIntegrated);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.ddlDatabase);
            this.groupBox1.Controls.Add(this.txtFilter);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(198, 422);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection Info";
            // 
            // ddlSchema
            // 
            this.ddlSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSchema.Enabled = false;
            this.ddlSchema.FormattingEnabled = true;
            this.ddlSchema.Location = new System.Drawing.Point(138, 205);
            this.ddlSchema.Name = "ddlSchema";
            this.ddlSchema.Size = new System.Drawing.Size(55, 21);
            this.ddlSchema.TabIndex = 8;
            this.ddlSchema.SelectedIndexChanged += new System.EventHandler(this.ddlSchema_SelectedIndexChanged);
            // 
            // lstServerData
            // 
            this.lstServerData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstServerData.Enabled = false;
            this.lstServerData.FormattingEnabled = true;
            this.lstServerData.Location = new System.Drawing.Point(6, 257);
            this.lstServerData.Name = "lstServerData";
            this.lstServerData.Size = new System.Drawing.Size(186, 160);
            this.lstServerData.TabIndex = 10;
            this.lstServerData.SelectedIndexChanged += new System.EventHandler(this.lstServerData_SelectedIndexChanged);
            this.lstServerData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstServerData_KeyPress);
            this.lstServerData.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lstServerData_KeyUp);
            // 
            // ddlType
            // 
            this.ddlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlType.Enabled = false;
            this.ddlType.FormattingEnabled = true;
            this.ddlType.Location = new System.Drawing.Point(7, 205);
            this.ddlType.Name = "ddlType";
            this.ddlType.Size = new System.Drawing.Size(125, 21);
            this.ddlType.TabIndex = 7;
            this.ddlType.SelectedIndexChanged += new System.EventHandler(this.ddlType_SelectedIndexChanged);
            // 
            // chkIntegrated
            // 
            this.chkIntegrated.AutoSize = true;
            this.chkIntegrated.Location = new System.Drawing.Point(7, 153);
            this.chkIntegrated.Name = "chkIntegrated";
            this.chkIntegrated.Size = new System.Drawing.Size(74, 17);
            this.chkIntegrated.TabIndex = 4;
            this.chkIntegrated.Text = "Integrated";
            this.chkIntegrated.UseVisualStyleBackColor = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(118, 149);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ddlDatabase
            // 
            this.ddlDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabase.Enabled = false;
            this.ddlDatabase.FormattingEnabled = true;
            this.ddlDatabase.Location = new System.Drawing.Point(7, 178);
            this.ddlDatabase.Name = "ddlDatabase";
            this.ddlDatabase.Size = new System.Drawing.Size(186, 21);
            this.ddlDatabase.TabIndex = 6;
            this.ddlDatabase.SelectedIndexChanged += new System.EventHandler(this.ddlDatabase_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Enabled = false;
            this.txtFilter.Location = new System.Drawing.Point(138, 231);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(55, 20);
            this.txtFilter.TabIndex = 9;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // txtPwd
            // 
            this.txtPwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwd.Location = new System.Drawing.Point(6, 123);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(186, 20);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.Text = "@123abc";
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(7, 234);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(72, 13);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Time connect";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Pwd";
            // 
            // txtUid
            // 
            this.txtUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUid.Location = new System.Drawing.Point(6, 74);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(186, 20);
            this.txtUid.TabIndex = 2;
            this.txtUid.Text = "sa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Uid";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.AutoCompleteCustomSource.AddRange(new string[] {
            "192.168.30.103",
            "192.168.30.222\\SQL2012",
            "192.168.30.173",
            "172.16.90.24",
            "DUCDHM\\MINHCHIEN"});
            this.txtServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtServer.Location = new System.Drawing.Point(6, 31);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(186, 20);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = ".";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(762, 444);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(754, 418);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Database Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblParamTotal);
            this.splitContainer2.Panel1.Controls.Add(this.ddlParamType);
            this.splitContainer2.Panel1.Controls.Add(this.txtParam);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.ddlGenerateType);
            this.splitContainer2.Panel2.Controls.Add(this.rtbOutput);
            this.splitContainer2.Size = new System.Drawing.Size(748, 412);
            this.splitContainer2.SplitterDistance = 151;
            this.splitContainer2.TabIndex = 0;
            // 
            // lblParamTotal
            // 
            this.lblParamTotal.AutoSize = true;
            this.lblParamTotal.Location = new System.Drawing.Point(3, 10);
            this.lblParamTotal.Name = "lblParamTotal";
            this.lblParamTotal.Size = new System.Drawing.Size(65, 13);
            this.lblParamTotal.TabIndex = 3;
            this.lblParamTotal.Text = "Total 0 Field";
            // 
            // ddlParamType
            // 
            this.ddlParamType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlParamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlParamType.FormattingEnabled = true;
            this.ddlParamType.Location = new System.Drawing.Point(47, 5);
            this.ddlParamType.Name = "ddlParamType";
            this.ddlParamType.Size = new System.Drawing.Size(101, 21);
            this.ddlParamType.TabIndex = 2;
            this.ddlParamType.SelectedIndexChanged += new System.EventHandler(this.ddlParamType_SelectedIndexChanged);
            // 
            // txtParam
            // 
            this.txtParam.AcceptsReturn = true;
            this.txtParam.AcceptsTab = true;
            this.txtParam.AllowDrop = true;
            this.txtParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtParam.Location = new System.Drawing.Point(3, 32);
            this.txtParam.Multiline = true;
            this.txtParam.Name = "txtParam";
            this.txtParam.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtParam.Size = new System.Drawing.Size(145, 377);
            this.txtParam.TabIndex = 1;
            this.txtParam.WordWrap = false;
            // 
            // ddlGenerateType
            // 
            this.ddlGenerateType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlGenerateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGenerateType.FormattingEnabled = true;
            this.ddlGenerateType.Location = new System.Drawing.Point(467, 5);
            this.ddlGenerateType.Name = "ddlGenerateType";
            this.ddlGenerateType.Size = new System.Drawing.Size(121, 21);
            this.ddlGenerateType.TabIndex = 11;
            this.ddlGenerateType.SelectedIndexChanged += new System.EventHandler(this.ddlGenerateType_SelectedIndexChanged);
            // 
            // rtbOutput
            // 
            this.rtbOutput.AcceptsTab = true;
            this.rtbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbOutput.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rtbOutput.Location = new System.Drawing.Point(3, 32);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(585, 377);
            this.rtbOutput.TabIndex = 1;
            this.rtbOutput.Text = "";
            // 
            // ctxMenuServerData
            // 
            this.ctxMenuServerData.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDataToolStripMenuItem,
            this.viewInfoToolStripMenuItem,
            this.dBBCRESESTEDToolStripMenuItem});
            this.ctxMenuServerData.Name = "contextMenuStrip1";
            this.ctxMenuServerData.Size = new System.Drawing.Size(160, 70);
            // 
            // viewDataToolStripMenuItem
            // 
            this.viewDataToolStripMenuItem.Name = "viewDataToolStripMenuItem";
            this.viewDataToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.viewDataToolStripMenuItem.Text = "View Data";
            this.viewDataToolStripMenuItem.Click += new System.EventHandler(this.viewDataToolStripMenuItem_Click);
            // 
            // viewInfoToolStripMenuItem
            // 
            this.viewInfoToolStripMenuItem.Name = "viewInfoToolStripMenuItem";
            this.viewInfoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.viewInfoToolStripMenuItem.Text = "View Info";
            this.viewInfoToolStripMenuItem.Click += new System.EventHandler(this.viewInfoToolStripMenuItem_Click);
            // 
            // dBBCRESESTEDToolStripMenuItem
            // 
            this.dBBCRESESTEDToolStripMenuItem.Name = "dBBCRESESTEDToolStripMenuItem";
            this.dBBCRESESTEDToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.dBBCRESESTEDToolStripMenuItem.Text = "DBBC RESESTED";
            this.dBBCRESESTEDToolStripMenuItem.Click += new System.EventHandler(this.dBBCRESESTEDToolStripMenuItem_Click);
            // 
            // ctxQueryOutput
            // 
            this.ctxQueryOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executeToolStripMenuItem,
            this.numberConnectToolStripMenuItem});
            this.ctxQueryOutput.Name = "contextMenuStrip2";
            this.ctxQueryOutput.Size = new System.Drawing.Size(167, 48);
            // 
            // executeToolStripMenuItem
            // 
            this.executeToolStripMenuItem.Name = "executeToolStripMenuItem";
            this.executeToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.executeToolStripMenuItem.Text = "Execute";
            this.executeToolStripMenuItem.Click += new System.EventHandler(this.executeToolStripMenuItem_Click);
            // 
            // numberConnectToolStripMenuItem
            // 
            this.numberConnectToolStripMenuItem.Name = "numberConnectToolStripMenuItem";
            this.numberConnectToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.numberConnectToolStripMenuItem.Text = "Number Connect";
            this.numberConnectToolStripMenuItem.Click += new System.EventHandler(this.numberConnectToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 472);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "frmMain";
            this.Text = "Generate Template";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ctxMenuServerData.ResumeLayout(false);
            this.ctxQueryOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.ListBox lstServerData;
        private System.Windows.Forms.ComboBox ddlType;
        private System.Windows.Forms.CheckBox chkIntegrated;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox ddlDatabase;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ctxMenuServerData;
        private System.Windows.Forms.ContextMenuStrip ctxQueryOutput;
        private System.Windows.Forms.ComboBox ddlSchema;
        private System.Windows.Forms.ComboBox ddlParamType;
        private System.Windows.Forms.Label lblParamTotal;
        private System.Windows.Forms.ToolStripMenuItem viewDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dBBCRESESTEDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem numberConnectToolStripMenuItem;
        private System.Windows.Forms.ComboBox ddlGenerateType;
    }
}

