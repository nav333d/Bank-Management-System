using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    class AccountDeactivation
    {
        SqlConnection Connection;
        SqlCommand Cmd;
        SqlDataReader Reader;


        CustomerLogin CLobj;
        AccountsManager AMobj = new AccountsManager();


        int AccountId;
        string pasword;

        public AccountDeactivation(int AccountId, string pasword)
        {
            this.AccountId = AccountId;
            this.pasword = pasword;

        }


        public string DeActivateAccount() // this method need some correction its not working correctly
        {
            string status = AMobj.CheckAccountStatus(AccountId);
            string dbpasword = "";

            string query = "Select Pasword from PersonnalData where AccountId=" + AccountId + "";
            Connection = new SqlConnection(Program.link);
            Connection.Open();
            Cmd = new SqlCommand(query, Connection);

            SqlDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
            {
                dbpasword = Reader["Pasword"].ToString();

            }
            Connection.Close();

            if (pasword == dbpasword)
            {
                if (status == "Active")
                {
                    try
                    {


                        string query1 = "Update PersonnalData set status='Deactive' where AccountId=" + AccountId + " and pasword='" + pasword + "'";
                        Connection = new SqlConnection(Program.link);
                        Connection.Open();

                        Cmd = new SqlCommand(query1, Connection);
                        Cmd.ExecuteNonQuery();

                        return "Account has been DeActivated";

                    }

                    catch
                    {
                        return "Your have Given some wrong Information";
                    }
                }
                else
                {
                    return "The Account is already been Deleted";
                }


            }
            else
            {
                return "You have Enterd Wrong Password!! please try Again";
            }
        }
    }
}
