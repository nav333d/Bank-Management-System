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
    public partial class AccountActivationForm : Form
    {
        public AccountActivationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountsManager AMobj = new AccountsManager();
            try
            {
                MessageBox.Show(AMobj.ActivateAccount(Convert.ToInt32(textBox1.Text), textBox2.Text));
                textBox1.Text = null;
                textBox2.Text = null;
            }
            catch
            {
                MessageBox.Show("OOPs !! Something Went Wrong");
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
