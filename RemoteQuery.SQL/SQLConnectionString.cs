using RemoteQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.SQL
{
    public sealed class SQLConnectionString : IConnectionString
    {
        public IAuthenticationType ConnectionType { get; set; }// = AuthenticationType.WindowsAuthenticationType;
        public ICredentials Credentials { get; set; }// = new Credentials();
        public string ServerName { get; set; }
        public string DBName { get; set; }

        public SQLConnectionString()
        {
            //_ConnectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return new SQLConnectionStringBuilder(this).BuildConnectionString();
        }

        //public abstract UserNameState GetUserNameState();
        //public abstract UserPasswordState GetUserPasswordState();
    }
}
