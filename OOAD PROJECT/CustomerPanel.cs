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
    public partial class CustomerPanel : Form
    {
        int id;
        public CustomerPanel(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WithdrawAmountForm form = new WithdrawAmountForm(id);
            form.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoneyTransferForm form = new MoneyTransferForm(id);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrontPage form = new FrontPage();
            this.Hide();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomerTransactionForm form = new CustomerTransactionForm();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //BillPaymentForm form = new BillPaymentForm();
            //form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CustomerLogin form = new CustomerLogin();
            //int id =form.GetAccountId();
            BalanceEnquiry beobj = new BalanceEnquiry(id);
            MessageBox.Show("your NetBalance is "+beobj.Checkbalance(id));
        }

        private void CustomerPanel_Load(object sender, EventArgs e)
        {
         
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
