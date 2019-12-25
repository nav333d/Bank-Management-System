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
    public partial class WithdrawAmountForm : Form
    {
        int id;
        public WithdrawAmountForm(int id)
        {
            this.id = id;//ye id use kro zra chal k dekh
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Connection;
            SqlCommand Cmd;
            string password="";
            string pasword = textBox1.Text;

            try
            {
                string query2 = "Select pasword from PersonnalData where AccountId=" + id + "";
                Connection = new SqlConnection(Program.link);
                Connection.Open();

                Cmd = new SqlCommand(query2, Connection);
                SqlDataReader Reader1 = Cmd.ExecuteReader();


                while (Reader1.Read())
                {
                    password = Reader1["Pasword"].ToString();
                }
                Connection.Close();


                if (password == pasword)
                {

                    TransactionManager tmobj = new TransactionManager();
                    MessageBox.Show(tmobj.WithdrawMoney(id, textBox1.Text, Convert.ToInt32(textBox2.Text)));

                    DateTime date = DateTime.Today;
                    tmobj.saveWithdrawalTrasaction(id, date, Convert.ToInt32(textBox2.Text));



                    textBox1.Text = null;
                    textBox2.Text = null;
                }
                else
                {
                    MessageBox.Show("you have entered wrong password");
 
 
                }
            }
            catch
            {
                MessageBox.Show("something Went wrong plz try Again");
 
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
