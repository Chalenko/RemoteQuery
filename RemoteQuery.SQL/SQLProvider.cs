using RemoteQuery.Model;
using System.Collections.Generic;
using System.Linq;

namespace RemoteQuery.SQL
{
    public sealed class SQLProvider : DbProvider
    {
        private const string _providerName = "SQL";
        public override string ProviderName => _providerName;

        private readonly IEnumerable<IAuthenticationType> _authenticationTypes = 
            new List<IAuthenticationType>() { AuthenticationType.WindowsAuthenticationType, AuthenticationType.NativeAuthenticationType.WithDisplayName(_providerName) };
        public override IEnumerable<IAuthenticationType> AuthenticationTypes => _authenticationTypes;

        private static SQLProvider _instance;
        private SQLProvider() //: base("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;") 
        {
            
        }

        public static SQLProvider Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLProvider();
                //_items = _items.Append(_instance);
                return _instance;
            }
        }

        public override IDatabaseContext GetDbContext(string connectionString)
        {
            return SQLDatabaseContext.GetInstance(connectionString);
        }
    }
}
