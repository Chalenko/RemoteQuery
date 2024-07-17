using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RemoteQuery.Models
{
    public abstract class AuthenticationType : IAuthenticationType
    {
        public string DisplayName { get; protected set; }

        public abstract string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
        //public abstract UserNameState GetUserNameState();
        //public abstract UserPasswordState GetUserPasswordState();

        protected static IEnumerable<IAuthenticationType> _items = new List<IAuthenticationType>();
        public static IEnumerable<IAuthenticationType> Items => _items.ToList();

        public static NativeAuthenticationType NativeAuthenticationType
        {
            get
            {
                return NativeAuthenticationType.Instance;
            }
        }

        public static WindowsAuthenticationType WindowsAuthenticationType
        {
            get
            {
                return WindowsAuthenticationType.Instance;
            }
        }
    }

    public class UserNameState
    {
        public string Name { get; private set; }
        public bool IsEditable { get; private set; }

        public UserNameState(string name, bool isEditable) 
        {
            Name = name;
            IsEditable = isEditable;
        }
    }

    public class UserPasswordState
    {
        public string Password { get; private set; }
        public bool IsEditable { get; private set; }

        public UserPasswordState(string password, bool isEditable)
        {
            Password = password;
            IsEditable = isEditable;
        }
    }

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
                _items.Append(_instance);
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
        }

        //public override UserNameState GetUserNameState() => new UserNameState(string.Empty, true);
        //public override UserPasswordState GetUserPasswordState() => new UserPasswordState(string.Empty, true);
    }

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
                _items.Append(_instance);
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Empty;// string.Format(_ConnectionString, serverName, dbName);
        }

        //public override UserNameState GetUserNameState() => new UserNameState(string.Format("{0}\\{1}", Environment.UserDomainName, Environment.UserName), false);
        //public override UserPasswordState GetUserPasswordState() => new UserPasswordState(string.Empty, false);
    }
}
