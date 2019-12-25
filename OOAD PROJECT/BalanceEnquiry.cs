using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class BalanceEnquiry
    {
        int AccountId;
        int NetBalance;
        SqlConnection Connection;
        SqlCommand Cmd;
        SqlDataReader Reader;

        public BalanceEnquiry(int AccountId)
        {
            this.AccountId = AccountId;
        }
        public BalanceEnquiry()
        {
            
        }

        public int Checkbalance(int AccountId)
        {
            string query = "select NetBalance from Balance where AccountId='" + AccountId + "'";
            Connection = new SqlConnection(Program.link);
            Connection.Open();

            Cmd = new SqlCommand(query, Connection);
            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                NetBalance = Convert.ToInt32(Reader["NetBalance"]);
            }

            return NetBalance;

            Connection.Close();
        }
    }
}
