using RemoteQuery.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace RemoteQuery.Model
{
    public sealed class SQLProvider : DbProvider
    {
        private const string _providerName = "SQL";
        public override string ProviderName => _providerName;

        private readonly IEnumerable<IAuthenticationType> _authenticationTypes = 
            new List<IAuthenticationType>() { AuthenticationType.WindowsAuthenticationType, AuthenticationType.NativeAuthenticationType.WithDisplayName(_providerName) };
        public override IEnumerable<IAuthenticationType> AuthenticationTypes => _authenticationTypes;

        private static SQLProvider _instance;
        private SQLProvider() : base(DbProviderEnum.SQL) 
        {
            
        }

        public static SQLProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLProvider();
                return _instance;
            }
        }
    }

    public partial class DbProvider
    {
        public static SQLProvider SQLProvider
        {
            get
            {
                return SQLProvider.Instance;
            }
        }
    }
}
