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
    public partial class AllTransactionForm : Form
    {
        public AllTransactionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransactionManager TMobj = new TransactionManager();
            try
            {


                dataGridView1.DataSource = TMobj.GetAllTransaction(Convert.ToInt16(textBox1.Text)).Tables[0];
            }
            catch
            {
                MessageBox.Show("Something Went Wrong!!!", "Alert");
            }
        }
    }
}
