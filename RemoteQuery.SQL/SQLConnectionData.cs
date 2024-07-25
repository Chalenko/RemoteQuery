using RemoteQuery.Model;
using RemoteQuery.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.SQL
{
    public sealed class SQLConnectionData : IConnectionData, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IAuthenticationType _connectionType = AuthenticationType.WindowsAuthenticationType;
        public IAuthenticationType ConnectionType 
        { 
            get => _connectionType;
            set
            {
                if (value == null)
                    return;
                _connectionType = value;
                OnPropertyChanged(nameof(ConnectionType));
                Credentials.UserName = value.GetUserNameState().Name;
                Credentials.Password = value.GetUserPasswordState().Password;
            }
        }

        public ICredentials Credentials { get; set; } = new Credentials();

        public IConnectionStringBuilder ConnectionStringBuilder { private get; set; } = new SQLConnectionStringBuilder();

        private string _serverName;
        public string ServerName
        {
            get => _serverName;
            set
            {
                _serverName = value;
                OnPropertyChanged(nameof(ServerName));
            }
        }

        private string _dbName;
        public string DBName
        {
            get => _dbName;
            set
            {
                _dbName = value;
                OnPropertyChanged(nameof(DBName));
            }
        }

        public SQLConnectionData()
        {
            //PropertyChanged += ServerNameChanged; 
            //PropertyChanged += DBNameChanged;
            //_ConnectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return ConnectionStringBuilder.BuildConnectionString(this);
        }

        public bool IsValid()
        {
            bool isWinAuthCorrect = 
                ConnectionType == AuthenticationType.WindowsAuthenticationType 
                && !ServerName.IsNullOrWhitespace()
                && !DBName.IsNullOrWhitespace();
            bool isNativeAuthCorrect =
                ConnectionType == AuthenticationType.NativeAuthenticationType
                && !ServerName.IsNullOrWhitespace()
                && !DBName.IsNullOrWhitespace()
                && !Credentials.UserName.IsNullOrWhitespace();
            return isWinAuthCorrect || isNativeAuthCorrect;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
