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

namespace WorkRequestSystem.Modules
{
    public partial class DatabaseManagementForm : Form
    {
        protected Database DB { get; set; } = new Database();

        public DatabaseManagementForm()
        {
            InitializeComponent();
        }

        public DatabaseManagementForm(Database db)
        {
            InitializeComponent();
            DB = db;
        }

        private void DatabaseManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}
