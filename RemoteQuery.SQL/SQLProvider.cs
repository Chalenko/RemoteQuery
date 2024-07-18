using RemoteQuery.Model;
using System.Collections.Generic;

namespace RemoteQuery.SQL
{
    public class SQLProvider : DbProvider
    {
        private const string _providerName = "SQL";
        public override string ProviderName => _providerName;

        private readonly IEnumerable<IAuthenticationType> _authenticationTypes = 
            new List<IAuthenticationType>() { AuthenticationType.WindowsAuthenticationType, AuthenticationType.NativeAuthenticationType.WithDisplayName(_providerName) };
        public override IEnumerable<IAuthenticationType> AuthenticationTypes => _authenticationTypes;

        public override IDatabaseContext GetDbContext(string connectionString)
        {
            return SQLDatabaseContext.GetInstance(connectionString);
        }
    }
}
