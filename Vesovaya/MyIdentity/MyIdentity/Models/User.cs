using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyIdentity
{
    public enum Roles { admin, user};
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UserName { get; set; }
        public User() { }

        public User(SqlDataReader reader)
        {
            Id = (int)reader["Id"];
            Name = reader["Name"].ToString();
            Surname = reader["Surname"].ToString();
            Age = (int)reader["Age"];
            RegisterDate = (DateTime)reader["RegisterDate"];
            UserName = reader["UserName"].ToString();
        }
    }

}
