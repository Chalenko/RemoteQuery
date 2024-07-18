using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class WindowsAuthenticationType : AuthenticationType
    {
        protected static WindowsAuthenticationType _instance;

        private WindowsAuthenticationType() //: base("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Timeout=60000;") 
        {
            DisplayName = "Windows";
        }

        public static WindowsAuthenticationType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WindowsAuthenticationType();
                //_items.Append(_instance);
                return _instance;
            }
        }
        public override string GetConnectionFormat()
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName);
        }

        public override UserNameState GetUserNameState() => new UserNameState(string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName), false);
        public override UserPasswordState GetUserPasswordState() => new UserPasswordState(string.Empty, false);
    }

    public partial class AuthenticationType
    {
        public static WindowsAuthenticationType WindowsAuthenticationType
        {
            get
            {
                return WindowsAuthenticationType.Instance;
            }
        }
    }
}
