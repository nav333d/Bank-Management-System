using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OOAD_PROJECT
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AccountsManager AMobj = new AccountsManager();
              MessageBox.Show(AMobj.ChangePassword(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text));
              
            }

            catch
            {
                MessageBox.Show("OOPs! Please Try Again");
            }
        }
    }
}
