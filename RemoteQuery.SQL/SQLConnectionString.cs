using RemoteQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.SQL
{
    public class SQLConnectionString : IConnectionString
    {
        private readonly string _baseConnectionString = "Data Source={0}; Initial Catalog={1}; Timeout=60000;";

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
            return string.Empty;
        }
        //public abstract UserNameState GetUserNameState();
        //public abstract UserPasswordState GetUserPasswordState();
    }
}
