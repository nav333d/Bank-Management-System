using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class LoginDetail
    {
        AccountsManager AMobj = new AccountsManager();

        SqlCommand Cmd;
        SqlConnection Connection;
        int AccountId; // id that user inputs
        string Password;     // password that user input on the form
        string query;
        int id;           // id that we get from the database to verify the user
        string pas;       // password that we get from database 
       
     

        public LoginDetail(int AccountId,string Password)
         {
             this.AccountId = AccountId;
             this.Password = Password;
            
        
            

        }

        public LoginDetail()
        {
           

        }

        public void GetIDPassword()
        {
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            query = "Select AccountId,Pasword from PersonnalData where AccountId="+AccountId;
            Cmd = new SqlCommand(query,Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                id = Convert.ToInt32(Reader["AccountId"]);
                pas = Reader["Pasword"].ToString();
              
                
                

            }


            Connection.Close();
        }

        

        public bool VerifyUser()
        {
         GetIDPassword();
         string status = AMobj.CheckAccountStatus(AccountId);
            bool check = false;
            if (AccountId == id && Password == pas && status == "Active")
            {
                check = true;
            }
            return check;
        }


        public string GetCustomerName(int AccountId) // this method shows the login customer name with Well come msg
        {
            String CustomerName="";
            string query = "Select CustomerName from PersonnalData where AccountId="+AccountId+"";
            Connection.Open();
            Cmd = new SqlCommand(query, Connection);

            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                CustomerName = Reader["CustomerName"].ToString();
            }

            return CustomerName;

            Connection.Close();
        }

        public bool VerifyAdmin()
        {
            string query = "select employeeNo from login where ";
            GetIDPassword();
            bool check = false;
            if (AccountId == id && Password == pas)
            {
                check = true;
            }
            return check;
        }


        
       

    }
}
