using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
namespace OOAD_PROJECT
{
    class CustomerInformation
    {
        int CustomerId;
        string CustomerName;
        int InitialBalance;
        string AccountType;
        string Address;
        string Gender;
        string CNIC;
        string ContactNumber;
        string MaritalStatus;
        string Nationality;
        int Age;

        int lastAccountId=0;
        string DOB;

        SqlConnection Connection;
        SqlCommand Cmd;
        SqlDataReader Reader;

        string query;


        public CustomerInformation( int CustomerId,int InitialBalance,string CustomerName,string AccountType,string Address,string Gender,string CNIC,string ContactNumber,string MaritalStatus,string nationality,int Age,string DOB)
        {
            this.CustomerId = CustomerId;
            this.CustomerName = CustomerName;
            this.InitialBalance = InitialBalance;
            this.AccountType = AccountType;
            this.Address = Address;
            this.Gender = Gender;
            this.CNIC = CNIC;
            this.ContactNumber = ContactNumber;
            this.MaritalStatus = MaritalStatus;
            this.Nationality = Nationality;
            this.Age = Age;
            this.DOB = DOB;
 
        }

        public CustomerInformation()
        { 

        }

        public string CreateAccount()
        {
            query = "Insert into PersonnalData (AccountId,CustomerName,InitialBalance,AccountType,Gender,Nationality,Address,Age,CNIC,ContactNumber,MaritalStatus,DOB,Status, Pasword) Values(" + CustomerId + ",'" + CustomerName + "'," + InitialBalance + ",'" + AccountType + "','" + Gender + "','" + Nationality + "','" + Address + "'," + Age + ",'" + CNIC + "','" + ContactNumber + "','" + MaritalStatus + "','" + DOB + "','Active','Wellcome')";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            Cmd = new SqlCommand(query,Connection);
            //Cmd.Parameters.Add(new OleDbParameter("@IMG", null));
            Cmd.ExecuteNonQuery();

            Connection.Close();
           string result = "The Account Has Been Created Successfully.\nYour Account ID is " + CustomerId + ".\nYour Password Is \"WellCome\"";
            return result;

            
 
        }

        public int GetAccountId() // this metod is to set automatically the account no for new account creation
        {
            string query = "Select Max (AccountId) from personnalData";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query, Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                lastAccountId = Convert.ToInt32(Reader[0]);

            }
            Connection.Close();
            lastAccountId=lastAccountId+1;
            return lastAccountId;

        }



    }
}
