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
    public partial class MoneyTransferForm : Form
    {
        int id;
        public MoneyTransferForm(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionManager TMobj = new TransactionManager();
                MessageBox.Show(TMobj.TransferMoney(id, Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text)) + "Generate Reciept?", "Succesfull", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
            catch
            {

                MessageBox.Show("You miss to input something");
                
            }

        }
    }
}
