using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class DepositionDetail
    {
        int AccountId;
        int Amount;

        int balance;
        string result;
        string status;

        SqlConnection Connection;
        SqlCommand Cmd;

        AccountsManager AMobj = new AccountsManager();


        public DepositionDetail(int AccountId, int Amount)
        {
            this.AccountId = AccountId;
            this.Amount = Amount;
        }
        public DepositionDetail()
        {
 
        }


        public string DepositAmount()
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

            status = AMobj.CheckAccountStatus(AccountId);

            if(status == "Active")
            {
           
                    Connection.Open();
                    balance = balance + Amount;
                    query = "Update Balance Set NetBalance = " + balance + " where AccountID = " + AccountId;
                    Cmd = new SqlCommand(query, Connection);
                    Cmd.ExecuteNonQuery();

                    result = "Operation Performs Successfully\nYour New Balance is " + balance;
                    Connection.Close();
                    return result;

                }
                else
                {
                    result = "The Account you trying to Depoist Monay is DeActivated or may not exist";
                    return result;
                }
           
        }
    }
}
