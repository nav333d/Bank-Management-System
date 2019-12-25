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
    public partial class DepositionForm : Form
    {
        public DepositionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionManager TMobj = new TransactionManager();
                MessageBox.Show(TMobj.DepositeAmount(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox3.Text)));
                TMobj.saveDepositTrasaction(Convert.ToInt32(textBox1.Text), DateTime.Today, Convert.ToInt32(textBox3.Text));
                textBox1.Text = null;
                textBox3.Text = null;
            }
            catch
            {
                MessageBox.Show("Either You missed to input Somethin or Some invalid input detected");
                textBox1.Text = null;
                textBox3.Text = null;
            }
        }
    }
}
