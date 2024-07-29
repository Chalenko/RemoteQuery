using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class RemoteQuery
    {
        public event PropertyChangedEventHandler ProviderChanged;
        public event PropertyChangedEventHandler ConnectionDataChanged;
        public event PropertyChangedEventHandler QueryTextChanged;

        public IDBRemoteQueryFactory RemoteQueryFactory { get; set; }

        private IDbProvider _provider;
        public IDbProvider Provider 
        { 
            get => _provider;
            set
            {
                _provider = value;
                if (ProviderChanged != null)
                    ProviderChanged(this, new PropertyChangedEventArgs(nameof(Provider)));
                ConnectionData = RemoteQueryFactory.CreateConnectionData();
                ConnectionData.PropertyChanged += ConnectionDataChanged;
            }
        }

        public ICredentials Credentials { get; } = new Credentials();

        public IConnectionData ConnectionData { get; private set; }

        public IAuthenticationType ConnectionType
        {
            get => ConnectionData.ConnectionType;
            set 
            {
                ConnectionData.ConnectionType = value;
                OnConnectionDataChanged(nameof(ConnectionType));
            }
        }

        private string _queryText = string.Empty;
        public string QueryText 
        {
            get => _queryText;
            set
            {
                _queryText = value;
                if (QueryTextChanged != null)
                    QueryTextChanged(this, new PropertyChangedEventArgs(nameof(QueryText)));
            }
        }

        private object _result = null;
        public object Result
        {
            get => _result;
            set
            {
                _result = value;
            }
        }

        private void OnConnectionDataChanged([CallerMemberName] string propertyName = "")
        {
            if (ConnectionDataChanged != null)
                ConnectionDataChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
