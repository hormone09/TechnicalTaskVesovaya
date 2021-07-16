using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentity.Managers
{
    public class UserManager : IUserManager
    {
        private SqlConnection connection = new SqlConnection();

        public UserManager()
        {
            connection = DataBaseContext.GetSqlConnection;
        }

        public bool CreateUserAsync(User user, string password, string roleName)
        {
            bool IsValid = Handler.ParamsHandler(new string[] { user.Name, user.Surname, password, roleName });
            if(IsValid)
            {
                bool IsUserNameCorrect = GetUser(user.UserName) == null;
                if (IsUserNameCorrect)
                {
                    string sqlExpression = "INSERT INTO Users (Name, Surname, Age, RegisterDate, UserName, PasswordHashCode)" +
                        "VALUES(@name, @surname, @age, @date, @userName, @passwordHash)";
                    connection.Open();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlParameter name = new SqlParameter("@name", user.Name);
                    SqlParameter surname = new SqlParameter("@surname", user.Surname);
                    SqlParameter age = new SqlParameter("@age", user.Age);
                    SqlParameter date = new SqlParameter("@date", user.RegisterDate);
                    SqlParameter userName = new SqlParameter("@userName", user.UserName);
                    SqlParameter passwordHash = new SqlParameter("@passwordHash", Handler.GetPasswordHash(password));
                    command.Parameters.Add(name);
                    command.Parameters.Add(surname);
                    command.Parameters.Add(age);
                    command.Parameters.Add(date);
                    command.Parameters.Add(userName);
                    command.Parameters.Add(passwordHash);

                    command.ExecuteNonQuery();
                    connection.Close();

                    return true;
                }
                else
                    return false;
            }
            else
                throw new Exception("Параметр задан неверно!");
        }

        public User Find(int id)
        {
            User user = null;
            using (connection)
            {
                string commandText = $"SELECT * FROM [Users] WHERE Id=@id";
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _id = new SqlParameter("@id", id);
                command.Parameters.Add(_id);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    if (!reader.IsDBNull(reader.GetOrdinal("Id")))
                        user = new User(reader);

                reader.Close();
                connection.Close();
                return user;
            }
        }

        public User GetUser(string userName)
        {
            bool IsValid = Handler.ParamsHandler(new string[] { userName });
            User user = null;
            if (IsValid)
            {
                string commandText = $"SELECT * FROM [Users] WHERE UserName=@userName";
                connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                command.Parameters.Add(_userName);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                        user = new User(reader);

                reader.Close();
                connection.Close();
                return user;
            }
            else
                throw new Exception("Параметр задан неверно!");
        }

        public bool UserIsAuthorize(string userName)
        {
            bool IsValid = Handler.ParamsHandler(new string[] { userName });
            bool result = false;
            if (IsValid)
            {
                string commandText = $"SELECT * FROM [AuthorizedUsers] WHERE UserName=@userName";
                if(connection.State.ToString().Equals("Closed"))
                    connection.Open();

                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                command.Parameters.Add(_userName);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                        result = true;
                    else
                        result = false;

                reader.Close();
                if (connection.State.ToString().Equals("Open"))
                    connection.Close();
                return result;
            }
            else
                throw new Exception("Параметр задан неверно!");
        }

    }
}
