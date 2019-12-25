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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountCreationForm form = new AccountCreationForm();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AccountDeactivationForm form = new AccountDeactivationForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccountUpdationForm form = new AccountUpdationForm();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            CustomerTransactionForm form = new CustomerTransactionForm();
            form.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DepositionForm form = new DepositionForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrontPage form = new FrontPage();
            this.Hide();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TrailBalanceForm form = new TrailBalanceForm();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AccountActivationForm form = new AccountActivationForm();
            form.Show();

        }
    }
}
