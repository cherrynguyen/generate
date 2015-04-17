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
    public partial class BrowseFile : UserControl
    {
        public string Filter { get; set; }

        public string LabelText
        {
            get
            {
                return lblChooseFile.Text;
            }
            set
            {
                lblChooseFile.Text = value;
            }
        }

        public event OnChoosedEventHandle ChoosedFile;
        public delegate void OnChoosedEventHandle(object sender, OnChoosedFileEventArg e);
        //public delegate void UserControlResult(string fileName, DialogResult result);
        //public UserControlResult UCDialogResult;
        public BrowseFile()
        {
            InitializeComponent();
        }
        public string FilePath
        {
            get
            {
                return txtFilePath.Text;
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            if (!string.IsNullOrEmpty(this.Filter))
                openDlg.Filter = string.Format("{0} file ({1})|*{1}", this.Filter.ToUpper(), this.Filter);
            var dlgResult = openDlg.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                txtFilePath.Text = openDlg.FileName;
                OnChoosedFile(new OnChoosedFileEventArg(openDlg.FileName));
            }
            //UCDialogResult(txtFilePath.Text, dlgResult);
        }

        public virtual void OnChoosedFile(OnChoosedFileEventArg e)
        {
            if (ChoosedFile != null)
                ChoosedFile(this, e);
        }
    }
    public class OnChoosedFileEventArg : EventArgs
    {
        public OnChoosedFileEventArg(string filePath)
        {
            this.FilePath = filePath;
            this.FileType = filePath.Substring(filePath.LastIndexOf("."));
        }
        public string FilePath { get; set; }
        public string FileType { get; set; }
    }
}
