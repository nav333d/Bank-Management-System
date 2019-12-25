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
    public partial class CustomerLogin : Form
    {
        public CustomerLogin()
        {
            InitializeComponent();

           
        }

        int Id;

        public int GetAccountId() // this method is for sending the id of a customer that logedinto the system
        {
            return Id = Convert.ToInt32(textBox1.Text);
            MoneyTransferForm from = new MoneyTransferForm(Id);
            BillPaymentForm form = new BillPaymentForm(Id);


        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                LoginManager manager = new LoginManager();
                if (manager.verify(Convert.ToInt32(textBox1.Text), textBox2.Text))
                {
                    MessageBox.Show("Well Come " + manager.PrintName(Convert.ToInt32(textBox1.Text)));
                    CustomerPanel form = new CustomerPanel(Convert.ToInt32(textBox1.Text));
                    form.Show();
                    this.Hide();
                    textBox1.Text = null;
                    textBox2.Text = null;
                    

                   


                }
                else
                {
                    MessageBox.Show(" The Account has been Deleted  ");
                    textBox1.Text = null;
                    textBox2.Text = null;
                }
            }


            catch 
            { 
                
                MessageBox.Show("PLEASE INPUT SOMETHING");
                textBox1.Text = null;
                textBox2.Text = null;
            }



          
             

           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
