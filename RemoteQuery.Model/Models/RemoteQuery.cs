using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class RemoteQuery
    {
        private ICredentials _credentials = new Credentials();
        private IConnectionString _connectionString;// = new SQLConnectionString("");
        public IAuthenticationType ConnectionType => _connectionString.ConnectionType;
        public string UserName => _credentials.UserName;
        public string Password => _credentials.Password;
        //public bool IsUserNameEditable => _connectionString.ConnectionType.GetUserNameState().IsEditable;
        //public bool IsPasswordEditable => _connectionString.ConnectionType.GetUserPasswordState().IsEditable;

        public string ServerName { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string QueryText { get; set; } = "Select 1";//string.Empty;
        public object Result { get; set; } = null;

        public string GetConnectionString() => string.Empty;// _connectionString.GetConnectionString(ServerName, DatabaseName, UserName, Password);
    }
}
