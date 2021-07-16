using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentity.Managers
{
    public class SignManager : ISignManager
    {
        private readonly SqlConnection connection;

        public SignManager()
        {
            connection = DataBaseContext.GetSqlConnection;
        }

        public bool SignIn(string userName, string password)
        {
            UserManager userManager = new UserManager();
            bool IsUserSigned = userManager.UserIsAuthorize(userName) == true;
            if (!IsUserSigned)
            {
                string passwordHash = Handler.GetPasswordHash(password);
                bool IsCurrentPassword = false;

                connection.Open();

                string commandText = $"SELECT * FROM [Users] WHERE UserName=@userName AND PasswordHashCode=@passwordHash";
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                SqlParameter _passwordHash = new SqlParameter("@passwordHash", passwordHash);
                command.Parameters.Add(_userName);
                command.Parameters.Add(_passwordHash);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                    if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                        IsCurrentPassword = true;
                reader.Close();

                if (IsCurrentPassword)
                {
                    string sqlExpression = "INSERT INTO AuthorizedUsers (UserName) VALUES(@userName)";
                    SqlCommand _command = new SqlCommand(sqlExpression, connection);
                    SqlParameter name = new SqlParameter("@userName", userName);
                    _command.Parameters.Add(name);
                    _command.ExecuteNonQuery();

                    connection.Close();
                    reader.Close();

                    string authorizedUser = LocalDataManager.CurrentUserName; // Убираем авторизованого сейчас
                    if (!authorizedUser.Equals("null"))
                        SignOut(authorizedUser);
                    LocalDataManager.WriteAuthorizedUser(userName);

                    return true;
                }
                else
                {
                    connection.Close();
                    reader.Close();
                    return false;
                }
            }
            else
                return false;
        }

        public void SignOut(string userName)
        {
            UserManager userManager = new UserManager();
            bool IsUserSigned = userManager.UserIsAuthorize(userName) == true;
            if (IsUserSigned)
            {
                connection.Open();

                string commandText = $"DELETE FROM [AuthorizedUsers] WHERE UserName=@userName";
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                command.Parameters.Add(_userName);
                command.ExecuteNonQuery();

                LocalDataManager.WriteAuthorizedUser("null");

                connection.Close();
            }
        }

        public bool AddUserToRole(string userName, Roles role)
        {
            bool IsUserInCurrentRole = IsUserInRole(userName, role);

            if (!IsUserInCurrentRole)
            {
                string sqlExpression = "INSERT INTO UsersInRole (UserName, RoleName) VALUES(@userName, @roleName)";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                SqlParameter _roleName = new SqlParameter("@roleName", role.ToString());
                command.Parameters.Add(_userName);
                command.Parameters.Add(_roleName);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            else
                return false;

        }
        public bool DeleteUserFromRole(string userName, Roles role)
        {
            bool _IsUserInRole = IsUserInRole(userName, role);
            if (_IsUserInRole)
            {
                connection.Open();

                string commandText = "DELETE FROM [UsersInRole] WHERE UserName=@userName AND RoleName=@roleName";
                SqlCommand command = new SqlCommand(commandText, connection);
                SqlParameter _userName = new SqlParameter("@userName", userName);
                SqlParameter _roleName = new SqlParameter("@roleName", role.ToString());
                command.Parameters.Add(_userName);
                command.Parameters.Add(_roleName);
                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            else
                return false;
        }

        public bool IsUserInRole(string userName, Roles role)
        {
            bool result = false;
            string commandText = "SELECT * FROM [UsersInRole] WHERE UserName=@userName AND RoleName=@roleName";
            connection.Open();

            SqlCommand command = new SqlCommand(commandText, connection);
            SqlParameter _userName = new SqlParameter("@userName", userName);
            SqlParameter _roleName = new SqlParameter("@roleName", role.ToString());
            command.Parameters.Add(_userName);
            command.Parameters.Add(_roleName);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
                if (!reader.IsDBNull(reader.GetOrdinal("UserName")))
                    result = true;
                else
                    result = false;

            reader.Close();
            connection.Close();
            
            return result;
        }
    }
}
