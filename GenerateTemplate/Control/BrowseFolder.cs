using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateTemplateUtils2014.Control
{
    public partial class BrowseFolder : UserControl
    {
        public BrowseFolder()
        {
            InitializeComponent();
            txtFolderPath.Text = DefaultFolder;
            if (IsShortUrl)
                txtFolderPath.Text = txtFolderPath.Text.Replace(Application.StartupPath, string.Empty);

        }
        public string DefaultFolder { get; set; }
        public bool IsShortUrl { get; set; }
        public string LabelText
        {
            get
            {
                return lblChooseFolder.Text;
            }
            set
            {
                lblChooseFolder.Text = value;
            }
        }

        public event OnChoosedEventHandle ChoosedFolder;
        public delegate void OnChoosedEventHandle(object sender, OnChoosedFolderEventArg e);
        //public delegate void UserControlResult(string fileName, DialogResult result);
        //public UserControlResult UCDialogResult;
        public string FilePath
        {
            get
            {
                return txtFolderPath.Text;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openDlg = new FolderBrowserDialog();
            var dlgResult = openDlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtFolderPath.Text = openDlg.SelectedPath;
                if (IsShortUrl)
                    txtFolderPath.Text = txtFolderPath.Text.Replace(Application.StartupPath, string.Empty);

                OnChoosedFolder(new OnChoosedFolderEventArg(txtFolderPath.Text));
            }
            //UCDialogResult(txtFilePath.Text, dlgResult);
        }

        public virtual void OnChoosedFolder(OnChoosedFolderEventArg e)
        {
            if (ChoosedFolder != null)
                ChoosedFolder(this, e);
        }
    }
    public class OnChoosedFolderEventArg : EventArgs
    {
        public OnChoosedFolderEventArg(string folderPath)
        {
            this.FolderPath = folderPath;
        }

        public string FolderPath { get; set; }
    }
}
