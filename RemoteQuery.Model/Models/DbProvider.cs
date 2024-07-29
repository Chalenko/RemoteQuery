using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public abstract partial class DbProvider : IDbProvider
    {
        protected DbProviderEnum _provider;
        protected static Dictionary<DbProviderEnum, DbProvider> _items = new Dictionary<DbProviderEnum, DbProvider>()
        {
           { DbProviderEnum.SQL, DbProvider.SQLProvider },
        };
        public static IEnumerable<DbProvider> Items { get => _items.Values.ToList(); }

        public abstract string ProviderName { get; }

        public abstract IEnumerable<IAuthenticationType> AuthenticationTypes { get; }

        protected DbProvider(DbProviderEnum provider) 
        {
            _provider = provider;
        }
    }

    public enum DbProviderEnum
    {
        [Description("SQL")]
        SQL = 0
    }
}
