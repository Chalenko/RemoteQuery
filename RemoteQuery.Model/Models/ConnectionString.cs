using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Models
{
    public class ConnectionString
    {
        internal readonly string _ConnectionString;

        public IAuthenticationType ConnectionType { get; set; } = AuthenticationType.WindowsAuthenticationType;
        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        //public abstract string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
        //public abstract UserNameState GetUserNameState();
        //public abstract UserPasswordState GetUserPasswordState();
    }
}
