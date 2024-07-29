using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RemoteQuery.Model
{
    public abstract partial class AuthenticationType : IAuthenticationType
    {
        public string DisplayName { get; protected set; }

        protected static IEnumerable<IAuthenticationType> _items = new List<IAuthenticationType>() 
        {
            NativeAuthenticationType,
            WindowsAuthenticationType,
        };

        public static IEnumerable<IAuthenticationType> Items { get => _items.ToList(); }

        public abstract UserNameState GetUserNameState();
        public abstract UserPasswordState GetUserPasswordState();
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
}
