using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public abstract partial class DbProvider : IDbProvider
    {
        //protected static IEnumerable<DbProvider> _items = new List<DbProvider>();
        //public static IEnumerable<DbProvider> Items { get => _items.ToList(); }

        public abstract string ProviderName { get; }

        public abstract IEnumerable<IAuthenticationType> AuthenticationTypes { get; }

        public abstract IDatabaseContext GetDbContext(string connectionString);
    }
}
