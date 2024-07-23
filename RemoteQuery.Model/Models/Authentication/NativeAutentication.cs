using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class NativeAuthenticationType : AuthenticationType
    {
        private static NativeAuthenticationType _instance;

        private NativeAuthenticationType()
        {
            DisplayName = "Native";
        }

        public static NativeAuthenticationType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NativeAuthenticationType();
                //_items.Append(_instance);
                return _instance;
            }
        }

        public override UserNameState GetUserNameState() => new UserNameState(string.Empty, true);
        public override UserPasswordState GetUserPasswordState() => new UserPasswordState(string.Empty, true);

        public NativeAuthenticationType WithDisplayName(string displayName)
        {
            _instance.DisplayName = displayName;
            return _instance;
        }
    }

    public partial class AuthenticationType
    {
        public static NativeAuthenticationType NativeAuthenticationType
        {
            get
            {
                return NativeAuthenticationType.Instance;
            }
        }
    }
}
