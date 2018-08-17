using DavesMasterWorkOrderRequestDatabase;
using DavesMasterWorkOrderRequestDatabase.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkRequestSystem.Classes;
using WorkRequestSystem.Modules;

namespace WorkRequestSystem
{
    public partial class Form1 : Form
    {
        private Database db;
        private RequestForm requestForm;
        private bool loggedIn;

        public Form1()
        {
            db = new Database();
            InitializeComponent();
        }

        protected bool CredentialsCheck()
        {
            if(!loggedIn)
            {

            }
            return true;
        }

        #region Form Events

        private void NewRequestBtn_Click(object sender, EventArgs e)
        {
            requestForm = new RequestForm(db);
            requestForm.CompletionEvent += OnRequestFormCompletion;
            requestForm.ShowDialog();
        }

        public void OnRequestFormCompletion(object sender, FormCompletionEventArgs e)
        {
            RequestFormCompletionData data = (RequestFormCompletionData)e.Data;
            db = data.db;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogExcel = new SaveFileDialog();
            saveFileDialogExcel.FileOk += SaveFileDialogExcel_FileOk;
            saveFileDialogExcel.ShowDialog();
        }

        private void SaveFileDialogExcel_FileOk(object sender, CancelEventArgs e)
        {
            if(!e.Cancel)
            {
                db.ExportToExcel(saveFileDialogExcel.FileName);
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogExcel = new OpenFileDialog();
            openFileDialogExcel.FileOk += OpenFileDialogExcel_FileOk;
            openFileDialogExcel.ShowDialog();
        }

        private void OpenFileDialogExcel_FileOk(object sender, CancelEventArgs e)
        {
            if(!e.Cancel)
            {
                db = Database.ImportFromExcel(openFileDialogExcel.FileName);
            }
        }

        #endregion
    }
}
