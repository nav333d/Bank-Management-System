using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace OOAD_PROJECT
{
    class TransactionManager
    {



        WithdrawalDetail wdobj = new WithdrawalDetail();
        MoneyTransfer MTobj = new MoneyTransfer();
        DepositionDetail DDobj = new DepositionDetail();

        SqlConnection Connection;
        SqlCommand Cmd;
        SqlDataReader Reader;

        SqlDataAdapter da;

        int IDs;


        public string WithdrawMoney(int AccountId, string Pasword, int Amount)
        {
            wdobj = new WithdrawalDetail(AccountId, Pasword, Amount);
            return wdobj.PerformAction();

        }

        public void saveWithdrawalTrasaction(int AccountId, DateTime TransactionDate, int Amount) // withdrawal  transactions saving method
        {

            int netamount = wdobj.GetNetBalance(AccountId);

            //int amountnet = netamount - Amount;


            string query1 = "insert into Transactions (AccountId,TransactionType,TransactionDate,Amount,NetBalance) values (" + AccountId + ",'Withdrawal','" + TransactionDate + "'," + Amount + "," + netamount + ")";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query1, Connection);
            Cmd.ExecuteNonQuery();
            Connection.Close();

            string query3 = "update Balance set NetBalance=" + netamount + " where AccountId=" + AccountId + "";
            Connection.Open();

            Cmd = new SqlCommand(query3, Connection);
            Cmd.ExecuteNonQuery();
            Connection.Close();


            string query2 = "insert into TrialBalance (AccountId,Debit,Credit,NetBalance,Eplanation) values  (" + AccountId + ",'--'," + Amount + "," + netamount + ",'Amount Withdrawal')";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query2, Connection);
            Cmd.ExecuteNonQuery();


        }
  
        public void saveDepositTrasaction(int AccountId, DateTime TransactionDate, int Amount) // Deposit transactions saving method
        {

            int netamount = wdobj.GetNetBalance(AccountId);

            //int amountnet = netamount + Amount;


            string query1 = "insert into Transactions (AccountId,TransactionType,TransactionDate,Amount,NetBalance) values (" + AccountId + ",'Deposit','" + TransactionDate + "'," + Amount + "," + netamount + ")";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query1, Connection);
            Cmd.ExecuteNonQuery();

            Connection.Close();

            


            string query2 = "insert into TrialBalance (AccountId,Debit,Credit,NetBalance,Eplanation) values  (" + AccountId + "," + Amount + ",'--'," + netamount + ",'Amount Deposited')";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query2, Connection);
            Cmd.ExecuteNonQuery();


        }

        public string TransferMoney(int senderAccountId, int ReceiverAccountId, string SenderPasword, int Amount)
        {
            MTobj = new MoneyTransfer(senderAccountId, ReceiverAccountId, SenderPasword, Amount);
            return MTobj.TransferMoney();

        }

        public string DepositeAmount(int AccountId, int Amount)
        {
            DDobj = new DepositionDetail(AccountId, Amount);
            return DDobj.DepositAmount();
        }


        public DataSet GetDepositTransaction(int AccountId)
        {
            string query = "Select AccountId,TransactionDate,Amount,NetBalance from Transactions where AccountId=" + AccountId + " and TransactionType='Deposit'";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.Fill(ds);
            return ds;
        }

        //public DataSet GetWithdrawalTransaction(int AccountId)
        //{
        //    string query = "Select AccountId,TransactionDate,Amount,NetBalance from Transactions where AccountId=" + AccountId + " and TransactionType='Withdrawal'";
        //    Connection = new SqlConnection(Program.link);
        //    Connection.Open();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
        //    adapter.Fill(ds);
        //    return ds;
        //}

        public DataSet GetAllTransaction(int AccountId)
        {
            string query = "Select AccountId,TransactionType,TransactionDate,Amount,NetBalance from Transactions where AccountId=" + AccountId + "";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetCustomerIDs()
        {
            string query = "Select AccountId from PersonnalData";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetWithdrawalTransaction(int AccountId)
        {
            string query = "Select AccountId,TransactionDate,Amount,NetBalance from Transactions where AccountId=" + AccountId + " and TransactionType='Withdrawal'";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.Fill(ds);
            return ds;
        }

        public DataSet GetTrialBalance(int AccountId)
        {
            string query = "Select AccountId,Debit,Credit,NetBalance,Eplanation from TrialBalance where AccountId=" + AccountId + "";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
            adapter.Fill(ds);
            return ds;
        }

        public string PayBill(int AccountId, int AmountPayable, string BillType)
        {
            int Billtopay = 0;
            int netamount = wdobj.GetNetBalance(AccountId);
            DateTime TransactionDate = DateTime.Today;
            string query2 = "select BillAmount from BillDeatail where AccountId=" + AccountId + " And BillType='" + BillType + "'";
            Connection = new SqlConnection(Program.link);
            Connection.Open();



            Cmd = new SqlCommand(query2, Connection);

            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                Billtopay = Convert.ToInt32(Reader["BillAmount"]);
            }



            Connection.Close();





            if (Billtopay > 0)
            {
                if (AmountPayable < netamount)
                {
                    if (BillType == "Electricity")
                    {
                        int NewnetBalance = netamount - AmountPayable;

                        string query = "update Balance set NetBalance=" + NewnetBalance + " where AccountId=" + AccountId + "";
                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();

                        string query1 = "insert into Transactions (AccountId,TransactionType,TransactionDate,Amount,NetBalance) Values(" + AccountId + ",'Electricity Bill Paid','" + TransactionDate + "'," + AmountPayable + "," + NewnetBalance + ")";

                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query1, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();

                        string query3 = "insert into TrialBalance (AccountId,Debit,Credit,NetBalance,Eplanation) Values(" + AccountId + ",'--','" + AmountPayable + "'," + NewnetBalance + ",'Electricity Bill Paid')";

                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query3, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();

                        return "You have Paid you bill Successfully";
                    }

                    else
                    {
                        int NewnetBalance = netamount - AmountPayable;

                        string query = "update Balance set NetBalance=" + NewnetBalance + " where AccountId=" + AccountId + "";
                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();

                        string query1 = "insert into Transactions (AccountId,TransactionType,TransactionDate,Amount,NetBalance) Values(" + AccountId + ",'Gas Bill Paid','" + TransactionDate + "'," + AmountPayable + "," + NewnetBalance + ")";

                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query1, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();

                        string query3 = "insert into TrialBalance (AccountId,Debit,Credit,NetBalance,Eplanation) Values(" + AccountId + ",'--','" + AmountPayable + "'," + NewnetBalance + ",'Gas Bill Paid')";

                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query3, Connection);
                        Cmd.ExecuteNonQuery();

                        Connection.Close();
                        return "You have Paid you bill Successfully";
                    }
                }
                else
                {
                    return "You don't have enough Balance to pay you bills";

                }
            }
            else
            {
                return "You  have  Already paid Your bill";
 
            }

        }
        











        }
    }

