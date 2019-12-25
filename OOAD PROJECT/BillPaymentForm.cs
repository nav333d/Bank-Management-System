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
    public partial class BillPaymentForm : Form
    {
        int AccountId;
        public BillPaymentForm(int AccountId)
        {
            this.AccountId = AccountId;
            InitializeComponent();
        }

        private void BillPaymentForm_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Electricity");
            comboBox1.Items.Add("Sui Gas");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TransactionManager TMobj = new TransactionManager();
            //TMobj.PayBill(AccountId, Convert.ToInt32(textBox1.Text), comboBox1.SelectedItem);
        }
    }
}
