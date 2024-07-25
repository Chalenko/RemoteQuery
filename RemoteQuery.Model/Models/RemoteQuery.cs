using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class RemoteQuery : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler ProviderChanged;

        public IDBRemoteQueryFactory RemoteQueryFactory { get; set; }

        private IDbProvider _provider;
        public IDbProvider Provider 
        { 
            get => _provider;
            set
            {
                //if (value == null)
                //    return;
                _provider = value;
                if (ProviderChanged != null)
                    ProviderChanged(this, new PropertyChangedEventArgs(nameof(Provider)));
                ConnectionData = RemoteQueryFactory.CreateConnectionData();
                ConnectionData.PropertyChanged += PropertyChanged;
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
                OnPropertyChanged(nameof(ConnectionType));
            }
        }

        private string _queryText = "Select 1";
        public string QueryText 
        {
            get => _queryText;
            set
            {
                _queryText = value;
                OnPropertyChanged(nameof(QueryText));
            }
        }

        private object _result = null;
        public object Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
