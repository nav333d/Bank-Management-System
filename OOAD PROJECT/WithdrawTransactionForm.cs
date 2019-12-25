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
    public partial class WithdrawTransactionForm : Form
    {
        
        public WithdrawTransactionForm()
        {
            
            InitializeComponent();
        }

        private void WithdrawTransactionForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            TransactionManager TMobj = new TransactionManager();
            dataGridView1.DataSource = TMobj.GetWithdrawalTransaction(Convert.ToInt16(textBox1.Text)).Tables[0];
            //SqlDataReader Reader;

            //try
            //{

            //    Reader = TMobj.GetDepositTransaction(Convert.ToInt32(textBox1.Text));
            //    dataGridView1.Rows.Clear();
            //    int i = 0;
            //    while (Reader.Read())
            //    {
            //        dataGridView1.Rows.Add();
            //        dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(i + 1);
            //        dataGridView1.Rows[i].Cells[1].Value = Reader[1].ToString();
            //        dataGridView1.Rows[i].Cells[3].Value = Reader[4].ToString();

            //        dataGridView1.Rows[i].Cells[4].Value = Reader[5].ToString();
            //        dataGridView1.Rows[i].Cells[5].Value = Reader[6].ToString();

            //        i++;
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Something Went Wrong!!!", "Alert");
            //}

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}