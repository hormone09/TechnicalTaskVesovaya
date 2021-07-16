using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentity
{
    public interface IUserManager
    {
        public bool CreateUserAsync(User user, string password, string roleName);
        public bool UserIsAuthorize(string userName);
        public User GetUser(string userName);
        public User Find(int id);
    }
}
