using DavesMasterWorkOrderRequestDatabase;
using DavesMasterWorkOrderRequestDatabase.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                MessageBox.Show("You must login first!");

                bool complete = false;

                LoginForm form = new LoginForm();
                form.SuccessEvent += Form_SuccessEvent;
                form.Disposed += Form_Disposed;
                form.ShowDialog();

                while (!complete)  // Wait until the dialog box closes
                {
                    Thread.Sleep(100);
                }

                return loggedIn;

                void Form_SuccessEvent(object sender, EventArgs e)
                {
                    loggedIn = true;
                    ((LoginForm)sender).Dispose();
                }

                void Form_Disposed(object sender, EventArgs e)
                {
                    complete = true;
                }
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
            if (CredentialsCheck())
            {
                saveFileDialogExcel = new SaveFileDialog();
                saveFileDialogExcel.FileOk += SaveFileDialogExcel_FileOk;
                saveFileDialogExcel.ShowDialog();
            }
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
            if (CredentialsCheck())
            {
                openFileDialogExcel = new OpenFileDialog();
                openFileDialogExcel.FileOk += OpenFileDialogExcel_FileOk;
                openFileDialogExcel.ShowDialog();
            }
        }

        private void OpenFileDialogExcel_FileOk(object sender, CancelEventArgs e)
        {
            if(!e.Cancel)
            {
                db = Database.ImportFromExcel(openFileDialogExcel.FileName);
            }
        }

        private void databaseManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(CredentialsCheck())
            {
                DatabaseManagementForm form = new DatabaseManagementForm();
                form.ShowDialog();
            }
        }

        #endregion
    }
}
