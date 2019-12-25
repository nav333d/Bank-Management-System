using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class MoneyTransfer
    {
        SqlConnection Connection;
        SqlCommand Cmd;
        AccountsManager AMobj = new AccountsManager();
        BalanceEnquiry BEobj = new BalanceEnquiry();
        int balance;
        

        int MoneyReceiverId;
        string SenderPasword;
        int Amount;
        int SenderAccountId;
        public MoneyTransfer()
        { }

        public MoneyTransfer(int SenderAccountId,int MoneyReceiverId, string SenderPasword, int Amount)
        {
            this.MoneyReceiverId = MoneyReceiverId;
            this.SenderPasword = SenderPasword;
            this.Amount = Amount;
            this.SenderAccountId = SenderAccountId;
        }

        public string TransferMoney() 
        {
            TransactionManager TMobj = new TransactionManager();
            string message="";
            string query = "Select NetBalance from balance Where AccountId="+MoneyReceiverId+"";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query,Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();


            while (Reader.Read())
            {
                balance = Convert.ToInt32(Reader["NetBalance"]);
            }
            Connection.Close();
            int MoneyRecievernewBalance = balance + Amount;

           string status= AMobj.CheckAccountStatus(MoneyReceiverId);
           int SenderOwnBalance = BEobj.Checkbalance(SenderAccountId);

           if (SenderOwnBalance >= Amount)
           {

               if (status == "Active")
               {
                   string query2 = "Update Balance set NetBalance=" + MoneyRecievernewBalance + " where AccountId=" + MoneyReceiverId + "";
                   Connection = new SqlConnection(Program.link);

                   Connection.Open();

                   Cmd = new SqlCommand(query2, Connection);
                   Cmd.ExecuteNonQuery(); 
                   Connection.Close();

                   // method to update the senders net amount after sendding money 
                   int SenderNewBalance = SenderOwnBalance - Amount;
                   string query3 = "Update Balance set NetBalance=" + SenderNewBalance + " where AccountId=" + SenderAccountId + "";
                   Connection = new SqlConnection(Program.link);
                   Connection.Open();

                   Cmd = new SqlCommand(query3, Connection);
                   Cmd.ExecuteNonQuery();
                   Connection.Close();

                   TMobj.saveWithdrawalTrasaction(SenderAccountId,DateTime.Today,Amount);
                   string query4 = "Update TrialBalance set NetBalance=" + SenderNewBalance + " where Credit='" +Amount  + "'";
                   Connection = new SqlConnection(Program.link);
                   Connection.Open();

                   Cmd = new SqlCommand(query4, Connection);
                   Cmd.ExecuteNonQuery();
                   Connection.Close();

                   TMobj.saveDepositTrasaction(MoneyReceiverId, DateTime.Today, Amount);
                   string query5 = "Update TrialBalance set NetBalance=" + MoneyRecievernewBalance + " where Debit='" + Amount + "'";
                   Connection = new SqlConnection(Program.link);
                   Connection.Open();

                   Cmd = new SqlCommand(query5, Connection);
                   Cmd.ExecuteNonQuery();
                   Connection.Close();


                   message= "Money Has been Successfully Transferd";
                   return message;

               }
               else if (status == "Deactive")
               {
                    message="The Account to which you want to TransferMoney is Deactive or Deleted";
                    return message;
               }
           }

           else
           {
               message = "Something Went Wrong";
               return message;
           }
           return message;
 
        }

    }
}
