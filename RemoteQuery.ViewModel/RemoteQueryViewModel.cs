using RemoteQuery.Model;
using RemoteQuery.SQL;
using RemoteQuery.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.ViewModel
{
    public class RemoteQueryViewModel //: INotifyPropertyChanged
    {
        private readonly string _connectionBaseText = "Соединение: ";
        private readonly string _statusBaseText = "Состояние: ";

        //public event PropertyChangedEventHandler PropertyChanged;

        public Model.RemoteQuery RemoteQuery { get; set; } = new Model.RemoteQuery();
        public IDatabaseContext DBContext { get; set; } = null;

        public bool IsExecuteEnabled { get; set; } = false;

        public bool IsTestConnectionEnabled { get; set; } = false;

        public string ConnectionString { get; set; } = string.Empty;

        private string _connectionStatus = string.Empty;
        public string ConnectionStatus
        {
            get => _connectionStatus;
            set
            {
                _connectionStatus = value;
                IsExecuteEnabled = _connectionStatus.Equals(ConnectionState.Open.ToString()) && !RemoteQuery.QueryText.IsNullOrWhitespace();
            }
        }

        public RemoteQueryViewModel()
        {
            RemoteQuery.ProviderChanged += RemoteQuery_ProviderChanged;
            RemoteQuery.ConnectionDataChanged += RemoteQuery_ConnectionDataChanged;
            RemoteQuery.QueryTextChanged += RemoteQuery_QueryTextChanged;
            //RemoteQuery.ConnectionData.PropertyChanged += RemoteQuery_PropertyChanged;
        }

        private void RemoteQuery_ProviderChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (RemoteQuery.Provider == DbProvider.SQLProvider)
                RemoteQuery.RemoteQueryFactory = new SQLFactory();
        }

        private void RemoteQuery_ConnectionDataChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsTestConnectionEnabled = RemoteQuery?.ConnectionData?.IsValid() ?? false;
            IsExecuteEnabled = _connectionStatus.Equals(ConnectionState.Open.ToString()) && !RemoteQuery.QueryText.IsNullOrWhitespace();
            ConnectionString = IsTestConnectionEnabled ? RemoteQuery.ConnectionData.GetConnectionString() : string.Empty;
            ConnectionStatus = string.Empty;
            if (e.PropertyName == nameof(RemoteQuery.Provider))
            {
                RemoteQuery_ProviderChanged(sender, e);
            }
        }

        private void RemoteQuery_QueryTextChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsExecuteEnabled = _connectionStatus.Equals(ConnectionState.Open.ToString()) && !RemoteQuery.QueryText.IsNullOrWhitespace();
        }

        public void TryConnect()
        {
            DBContext = RemoteQuery.RemoteQueryFactory.GetDbContext(RemoteQuery);
            DBContext.Connect();
            ConnectionStatus = DBContext.Status;
        }

        public void ExecuteQuery()
        {
            DBContext = RemoteQuery.RemoteQueryFactory.GetDbContext(RemoteQuery);
            RemoteQuery.Result = DBContext.LoadFromDatabase(RemoteQuery.QueryText, CommandType.Text);
        }


        //public IEnumerable<IDbProvider> Providers { get; set; }

        //public IDbProvider DelectedProvider { get; set; }

        //public IEnumerable<IAuthenticationType> AuthenticationTypes { get; set; }

        //public IAuthenticationType AuthenticationType { get; set; }

        //public IConnectionString ConnectionString { get; set; }

        //public string ServerName { get; set; }

        //public string UserName { get; set; }
    }
}
