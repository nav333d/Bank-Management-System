using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;




namespace OOAD_PROJECT
{
    public partial class DepositTransactionForm : Form
    {
        public DepositTransactionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransactionManager TMobj = new TransactionManager();
            

            try
            {


                dataGridView1.DataSource = TMobj.GetDepositTransaction(Convert.ToInt16(textBox1.Text)).Tables[0];
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!!!", "Alert");
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
