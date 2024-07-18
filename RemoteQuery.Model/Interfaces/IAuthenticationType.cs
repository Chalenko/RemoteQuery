using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public interface IAuthenticationType
    {
        string GetConnectionFormat();
        string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
        UserNameState GetUserNameState();

        UserPasswordState GetUserPasswordState();
    }
}
