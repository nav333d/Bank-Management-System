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
    public partial class CustomerTransactionForm : Form
    {
        public CustomerTransactionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                DepositTransactionForm form = new DepositTransactionForm();
                form.Show();
            }
            else if (radioButton2.Checked)
            {
                WithdrawTransactionForm form = new WithdrawTransactionForm();
                form.Show();

            }
            else
            {
                AllTransactionForm form = new AllTransactionForm();
                form.Show();
 
            }
        }
    }
}
