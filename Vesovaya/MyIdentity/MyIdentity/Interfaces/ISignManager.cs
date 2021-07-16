using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyIdentity.Managers
{
    public interface ISignManager
    {
        public bool SignIn(string userName, string password);
        public void SignOut(string userName);
        public bool IsUserInRole(string userName, Roles role);
        public bool AddUserToRole(string userName, Roles role);
    }
}
