using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOAD_PROJECT
{
    class LoginManager
    {
        LoginDetail login;

        public bool verify(int AccountId, string password)
        {
            login = new LoginDetail(AccountId,password);
            return login.VerifyUser();
        }

        public String PrintName(int AccountId)
        {
           return login.GetCustomerName(AccountId);
        }
    }
}
