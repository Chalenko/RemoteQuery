using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class NativeAuthenticationType : AuthenticationType
    {
        protected static NativeAuthenticationType _instance;

        private NativeAuthenticationType() //: base("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;") 
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

        public override string GetConnectionFormat()
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
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
