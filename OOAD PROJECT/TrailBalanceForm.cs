using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace OOAD_PROJECT
{
    public partial class TrailBalanceForm : Form
    {
        public TrailBalanceForm()
        {
            InitializeComponent();
        }

        private void TrailBalanceForm_Load(object sender, EventArgs e)
        {
            TransactionManager TMobj = new TransactionManager();
          //  comboBox1.Text = TMobj.GetCustomerIDs().ToString();

            //comboBox1.DataSource = TMobj.GetCustomerIDs().Tables[0].ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TransactionManager TMobj = new TransactionManager();
            try
            {
                dataGridView1.DataSource = TMobj.GetTrialBalance(Convert.ToInt16(textBox1.Text)).Tables[0];
            }
            catch
            { MessageBox.Show("oops!! something went wrong try again"); }
        }
    }
}
