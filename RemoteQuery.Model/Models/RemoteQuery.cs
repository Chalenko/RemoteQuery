using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Models
{
    public class RemoteQuery
    {
        private Credentials credentials = new Credentials();
        public IAuthenticationType ConnectionType => credentials.ConnectionType;
        public string UserName => credentials.UserName;
        public string Password => credentials.Password;
        public bool IsUserNameEditable => credentials.ConnectionType.GetUserNameState().IsEditable;
        public bool IsPasswordEditable => credentials.ConnectionType.GetUserPasswordState().IsEditable;

        public string ServerName { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string QueryText { get; set; } = "Select 1";//string.Empty;
        public object Result { get; set; } = null;

        public string GetConnectionString() => ConnectionType.GetConnectionString(ServerName, DatabaseName, UserName, Password);
    }
}
