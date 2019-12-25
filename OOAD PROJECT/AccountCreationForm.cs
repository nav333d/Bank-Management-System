using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace OOAD_PROJECT
{
    public partial class AccountCreationForm : Form
    {
        public AccountCreationForm()
        {
            InitializeComponent();
        }

        OpenFileDialog open;
        int InitialBalance;
        string AccountType;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void AccountCreationForm_Load(object sender, EventArgs e)
        {
            CustomerInformation ciobj = new CustomerInformation();
            textBox1.Text = ciobj.GetAccountId().ToString();
        }

        //private void pictureBox1_Click(object sender, EventArgs e)
        //{

        //    open = new OpenFileDialog();
        //    open.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
        //    if (open.ShowDialog() == DialogResult.OK)
        //    {
        //        pictureBox1.ImageLocation = open.FileName.ToString();
        //        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //    }

        //}

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int CurrentDate = DateTime.Now.Year;
            int DateofBirth = dateTimePicker1.Value.Year;
            textBox11.Text = (CurrentDate - DateofBirth).ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               InitialBalance= Convert.ToInt32(textBox2.Text);
               if (InitialBalance >= 5000)
               {
                   if (radioButton1.Checked)
                   {
                       AccountType = radioButton1.Text;
                       MessageBox.Show("DATA SAVED", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       tabControl1.SelectedTab = tabPage2;
                   }
                   else if (radioButton2.Checked)
                   {
                       AccountType = radioButton2.Text;
                       MessageBox.Show("DATA SAVED", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       tabControl1.SelectedTab = tabPage2;
                   }
               }
               else
               {
                   MessageBox.Show("Account Cannot be created with this Amount");
               }

            }
            catch
            {
                MessageBox.Show("Invalid Inputs", "Wrong Inputs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //awaz khol le
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int age = Convert.ToInt32(textBox11.Text);
                int InitialBalance = Convert.ToInt32(textBox2.Text);
                try
                {
                    if (age >= 18)
                    {
                        if (radioButton1.Checked)
                        {

                            AccountsManager AMobj = new AccountsManager();

                            DateTime DOB = dateTimePicker1.Value.Date;


                            string data = AMobj.CreateAccount(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox4.Text,/* AccountType*/"Current", textBox5.Text, textBox6.Text,
                                               maskedTextBox2.Text, maskedTextBox1.Text, textBox8.Text, textBox7.Text, Convert.ToInt32(textBox11.Text), DOB.ToString());
                            MessageBox.Show(data);

                            AMobj.NetBalance(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));//data sending into balance table
                            textBox4.Text = null;
                            textBox5.Text = null;
                            textBox11.Text = null;
                            textBox6.Text = null;
                            textBox7.Text = null;
                            textBox8.Text = null;
                            maskedTextBox2.Text = null;
                            maskedTextBox1.Text = null;

                        }
                        else
                        {

                            AccountsManager AMobj = new AccountsManager();

                            DateTime DOB = dateTimePicker1.Value.Date;


                            string data = AMobj.CreateAccount(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox4.Text,/* AccountType*/"Saving", textBox5.Text, textBox6.Text,
                                               maskedTextBox2.Text, maskedTextBox1.Text, textBox8.Text, textBox7.Text, Convert.ToInt32(textBox11.Text), DOB.ToString());
                            MessageBox.Show(data);

                            AMobj.NetBalance(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));//data sending into balance table
                            textBox4.Text = null;
                            textBox5.Text = null;
                            textBox11.Text = null;
                            textBox6.Text = null;
                            textBox7.Text = null;
                            textBox8.Text = null;
                            maskedTextBox2.Text = null;
                            maskedTextBox1.Text = null;
                        
                        
                        }


                    }
                    else
                    {
                        MessageBox.Show("your age is below the standard");
                        textBox4.Text = null;
                        textBox5.Text = null;
                        textBox11.Text = null;
                        textBox6.Text = null;
                        textBox7.Text = null;
                        textBox8.Text = null;
                        maskedTextBox2.Text = null;
                        maskedTextBox1.Text = null;
                    }
                }

                catch
                {
                    MessageBox.Show("something went wrong");
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox11.Text = null;
                    textBox6.Text = null;
                    textBox7.Text = null;
                    textBox8.Text = null;
                    maskedTextBox2.Text = null;
                    maskedTextBox1.Text = null;

                }
            }
            catch
            {
                MessageBox.Show("Fill the Required Field or you filld incorrectly");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox5.Text = null;
            textBox11.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            textBox8.Text = null;
            maskedTextBox2.Text = null;
            maskedTextBox1.Text = null;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
