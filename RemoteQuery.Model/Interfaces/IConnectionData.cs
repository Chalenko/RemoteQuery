using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public interface IConnectionData : INotifyPropertyChanged
    {
        IAuthenticationType ConnectionType { get; set; }
        ICredentials Credentials { get; }
        IConnectionStringBuilder ConnectionStringBuilder { set; }

        string GetConnectionString();
        bool IsValid();








        string ServerName { get; set; }
        string DBName { get; set; }
    }
}
