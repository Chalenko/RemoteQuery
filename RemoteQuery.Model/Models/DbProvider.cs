using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public abstract class DbProvider : IDbProvider
    {
        protected static IEnumerable<string> _items = new List<string>();
        public static IEnumerable<string> Items { get => _items.ToList(); }

        public abstract string ProviderName { get; }

        public abstract IEnumerable<IAuthenticationType> AuthenticationTypes { get; }

        public abstract IDatabaseContext GetDbContext(string connectionString);
    }
}
