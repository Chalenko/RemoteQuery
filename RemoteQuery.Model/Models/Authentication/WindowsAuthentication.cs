using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class WindowsAuthenticationType : AuthenticationType
    {
        private static WindowsAuthenticationType _instance;

        private WindowsAuthenticationType()
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
