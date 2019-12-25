using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class AccountsManager
    {
        CustomerInformation CustomerObj;
        SqlConnection Connection;
        SqlCommand Cmd;

             public string CreateAccount( int CustomerId,int InitialBalance,string CustomerName,string AccountType,string Address,string Gender,string CNIC,string ContactNumber,string MaritalStatus,string Nationality,int Age,string  DOB)
             {
                 CustomerObj = new CustomerInformation(CustomerId, InitialBalance,CustomerName, AccountType, Address, Gender, CNIC, ContactNumber, MaritalStatus, Nationality, Age, DOB);
                  return CustomerObj.CreateAccount();
    
              }


             public void NetBalance(int AccountId,int balance) // this method will be called where the deposition is performed
             {
                 string query = "Insert into Balance (AccountId,NetBalance) values ("+AccountId+","+balance+")";
                 Connection = new SqlConnection(Program.link);
                 Connection.Open();

                 Cmd = new SqlCommand(query,Connection);
                 Cmd.ExecuteNonQuery();
                 Connection.Close();

 
             }

             public string ChangePassword(int AccountId,string Pasword,string newpasword) // Change password method
             {
                 string oldPasword="";
                 string query = "select Pasword from PersonnalData where AccountId ="+AccountId+"";
                 Connection = new SqlConnection(Program.link);
                 Connection.Open();

                 Cmd = new SqlCommand(query,Connection);
                 SqlDataReader Reader = Cmd.ExecuteReader();


                 while (Reader.Read())
                 {
                     oldPasword = Reader["pasword"].ToString();
                 }
                 Connection.Close();
                 if (oldPasword == Pasword)
                 {
                     String query1 = "Update PersonnalData set Pasword='" + newpasword + "' where AccountId=" + AccountId + " ";
                     //Connection = new SqlConnection(Program.link);
                     Connection.Open();
                     Cmd = new SqlCommand(query1, Connection);
                     Cmd.ExecuteNonQuery();
                     Connection.Close();


                     string result = "Your Password has Successfully Changed";
                     return result;

                 }
                 else
                 {
                     string result = "Something went Wrog !! Please try Again";
                     return result;
 
                 }
 
             }

             public string CheckAccountStatus(int AccountId) // this method provide the status of a particular Account holder
             {
                 string status = "";
                 string query = "Select Status from PersonnalData Where AccountId=" + AccountId+ "";
                 Connection = new SqlConnection(Program.link);
                 Connection.Open();

                 Cmd = new SqlCommand(query, Connection);
                 SqlDataReader Reader = Cmd.ExecuteReader();


                 while (Reader.Read())
                 {
                    status  = Reader["Status"].ToString();
                 }
                 Connection.Close();

                 return status;

 
             }
             public string DeActivateAccount(int AccountId, string pasword)
             {
                 AccountDeactivation ADobj = new AccountDeactivation(AccountId,pasword);
                return  ADobj.DeActivateAccount();

                

             }

             public string UpdateAccountInformation(int AccountId,string AccountType ,string Address,string MaritalStatus,string ContactNumber)
             {
                 string query = "Update PersonnalData set AccountType='"+AccountType+"',Address='"+Address+"',MaritalStatus='"+MaritalStatus+"',ContactNumber="+ContactNumber+"";
                 Connection = new SqlConnection(Program.link);
                 Connection.Open();

                 Cmd = new SqlCommand(query,Connection);
                 Cmd.ExecuteNonQuery();

                 Connection.Close();

                 return "Account has been Successfully Updated";
 
             }

             public string ActivateAccount(int AccountId,string password)
             {
                 string Status = "";
                 string dbpasword = "";
                 string query = "Select Status,Pasword from PersonnalData where AccountId="+AccountId+"";
                 Connection = new SqlConnection(Program.link);

                 Connection.Open();

                 Cmd = new SqlCommand(query,Connection);
                 SqlDataReader Reader = Cmd.ExecuteReader();

                

                 while (Reader.Read())
                 {
                     Status = Reader["Status"].ToString();
                     dbpasword = Reader["Pasword"].ToString();

                 }
                 Connection.Close();

                 if (password == dbpasword)
                 {

                     if (Status == "Deactive")
                     {
                         string query1 = "Update PersonnalData set Status='Active' where AccountId=" + AccountId + "";
                         Connection = new SqlConnection(Program.link);
                         Connection.Open();

                         Cmd = new SqlCommand(query1, Connection);
                         Cmd.ExecuteNonQuery();
                         Connection.Close();

                         return "The Account has been Activated";

                     }
                     else
                     {
                         return "The Account is already been Active";
                     }
                 }
                 else
                 {
                     return "You have entered wrong password";
                 }

             }

    }
}
