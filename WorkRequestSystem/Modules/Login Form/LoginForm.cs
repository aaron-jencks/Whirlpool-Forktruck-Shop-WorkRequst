using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkRequestSystem.Modules.Login_Form
{
    public partial class LoginForm : Form
    {
        #region Properties

        private static string password = "Password";

        #endregion

        public LoginForm()
        {
            InitializeComponent();
        }

        private void OkayBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != password)
                MessageBox.Show("Incorrect Password");
            else
                OnSuccessEvent();
            Dispose();
        }

        public delegate void SuccessEventHandler(object sender, EventArgs e);

        public event SuccessEventHandler SuccessEvent;

        protected virtual void OnSuccessEvent()
        {
            SuccessEvent?.Invoke(this, new EventArgs());
        }
    }
}
