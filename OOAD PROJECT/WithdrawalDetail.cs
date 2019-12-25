using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace OOAD_PROJECT
{
    class WithdrawalDetail
    {
        int AccountId;
        string pasword ; // this is the password that user enters
        int Amount ;
        int balance;
        string result;

        string password; // this is the password that i fetch from database for a particular user

  

        SqlConnection Connection;
        SqlCommand Cmd;

        

        public WithdrawalDetail(int AccountId,string Pasword,int Amount)
        {
            this.AccountId = AccountId;
            this.pasword = Pasword;
            this.Amount = Amount;
 
        }


        public WithdrawalDetail()
        {
           

        }



        public string PerformAction()
        {


            string query = "select NetBalance From Balance where AccountID = " + AccountId;
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query, Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();


            while (Reader.Read())
            {
                balance = Convert.ToInt32(Reader["NetBalance"]);
            }
            Connection.Close();

            //string query2 = "Select pasword from PersonnalData where AccountId=" + AccountId + "";
            //Connection = new SqlConnection(Program.link);
            //Connection.Open();

            //Cmd = new SqlCommand(query2, Connection);
            //SqlDataReader Reader1 = Cmd.ExecuteReader();


            //while (Reader1.Read())
            //{
            //    password = Reader1["Pasword"].ToString();
            //}
            //Connection.Close();


            //if (password == pasword)
            //{
                if (Amount <= balance)
                {
                    Connection.Open();
                    balance = balance - Amount;
                    query = "Update Balance Set NetBalance = " + balance + " where AccountID = " + AccountId;
                    Cmd = new SqlCommand(query, Connection);
                    Cmd.ExecuteNonQuery();

                    result = "Operation Performs Successfully\nYour New Balance is " + balance;
                    Connection.Close();
                }
                else
                {
                    result = "Can not Withdrow!!!\nNot Enough Money";
                }
                return result;
            }
            //else {
            //     result = "You have Enterd wrong password";
            //     return result;

            //}
        
        
 
    

        public int GetNetBalance(int id)
        {
            string query = "select NetBalance From Balance where AccountID = " + id;
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query, Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();


            while (Reader.Read())
            {
                balance = Convert.ToInt32(Reader["NetBalance"]);
            }
            return balance;
            Connection.Close();
        }





    }
}
