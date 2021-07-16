using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MyIdentity
{
    public static class DataBaseContext
    {
        private static readonly SqlConnection context;
        private const string connectionString =
            "Data Source=SQL5105.site4now.net;Initial Catalog=db_a75f6f_vesovaya123;User Id=db_a75f6f_vesovaya123_admin;Password=vesovaya123";
            //"Server=DESKTOP-7FUSBPQ;Database=Vesovaya;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public static SqlConnection GetSqlConnection { get { return context; } }

        static DataBaseContext()
        {
            context = new SqlConnection(connectionString);
        }


    }
}
