using RemoteQuery.Model;
using RemoteQuery.SQL;
using RemoteQuery.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.ViewModel
{
    public class RemoteQueryViewModel
    {
        public Model.RemoteQuery RemoteQuery { get; set; } = new Model.RemoteQuery();

        public bool IsExecuteEnabled { get; set; } = false;

        public bool IsTestConnectionEnabled { get; set; } = false;

        public string ConnectionString { get; set; }

        public string ConnectionStatus { get; set; }

        public RemoteQueryViewModel()
        {
            RemoteQuery.PropertyChanged += RemoteQuery_PropertyChanged;
            RemoteQuery.ProviderChanged += RemoteQuery_ProviderChanged;
            //RemoteQuery.ConnectionData.PropertyChanged += RemoteQuery_PropertyChanged;
        }

        private void RemoteQuery_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsTestConnectionEnabled = RemoteQuery?.ConnectionData?.IsValid() ?? false;
            if (e.PropertyName == nameof(RemoteQuery.Provider))
            {
                if (RemoteQuery.Provider == DbProvider.SQLProvider)
                    RemoteQuery.RemoteQueryFactory = new SQLFactory();
            }
        }

        private void RemoteQuery_ProviderChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (RemoteQuery.Provider == DbProvider.SQLProvider)
                RemoteQuery.RemoteQueryFactory = new SQLFactory();
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
