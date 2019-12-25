using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;

namespace OOAD_PROJECT
{
    static class Program
    {
        public static string link = "Data Source=DESKTOP-QRM5H3H\\SQLEXPRESS;Initial Catalog=BankSystem;Integrated Security=True";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminPanel());
            
        }
    }
}
