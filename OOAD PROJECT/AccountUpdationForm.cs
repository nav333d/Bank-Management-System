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
    public partial class AccountUpdationForm : Form
    {
        public AccountUpdationForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Connection;
                SqlCommand Cmd;
                SqlDataReader Reader;

                int LastId = 0;
                 int AccountId = Convert.ToInt32(textBox1.Text);

                string query1 = "Select Last(AccountId) from PersonnalData";

                Connection = new SqlConnection(Program.link);
                Connection.Open();

                Cmd = new SqlCommand(query1, Connection);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                   LastId =Convert.ToInt32( Reader["AccountId"]);
                }
                Connection.Close();

                if(AccountId <= LastId)
                    {
                     string query = "Select * from PersonnalData where AccountId=" + AccountId + "";

                         Connection = new SqlConnection(Program.link);
                         Connection.Open();

                Cmd = new SqlCommand(query, Connection);
                Reader = Cmd.ExecuteReader();

                while (Reader.Read())
                {
                    textBox2.Text = Reader[1].ToString();
                    textBox7.Text = Reader[3].ToString();
                    textBox6.Text = Reader[7].ToString();
                    textBox5.Text = Reader[6].ToString();
                    textBox10.Text = Reader[4].ToString();
                    textBox3.Text = Reader[8].ToString();
                    textBox9.Text = Reader[10].ToString();
                    textBox8.Text = Reader[5].ToString();
                    textBox4.Text = Reader[9].ToString();
                }
                Connection.Close();
            }
                else
                {
                    MessageBox.Show("The Account may not exist or Deactivated");
                }
         }
          

            catch
            {
                MessageBox.Show("Either you missed to fill the required fields or you entered something invalid");
            }
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AccountsManager AMobj = new AccountsManager();

                MessageBox.Show(AMobj.UpdateAccountInformation(Convert.ToInt32(textBox1.Text), textBox7.Text, textBox5.Text, textBox9.Text, textBox4.Text));
            }
            catch
            {
                MessageBox.Show("You have entered some Wrong input!! please check again");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
