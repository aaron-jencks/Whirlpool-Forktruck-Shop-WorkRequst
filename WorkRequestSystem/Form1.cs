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

        public Form1()
        {
            db = new Database();
            InitializeComponent();
        }

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
    }
}
