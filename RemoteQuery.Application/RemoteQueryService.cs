using RemoteQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Application
{
    public class RemoteQueryService
    {
        private IDBRemoteQueryFactory _creator = null;

        private Model.RemoteQuery _query = null;
        public Model.RemoteQuery Query 
        {
            get => _query;
            set 
            {
                _query = value;
            }
        }

        public RemoteQueryService(IDBRemoteQueryFactory factory)
        {
            _creator = factory;
        }

        //public RemoteQueryService(Model.RemoteQuery query) : this(factory)
        //{
        //    _query = query;
        //    _query.ProviderChanged += Query_ProviderChanged;
        //}

        //private void Query_ProviderChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    if (_query.Provider == DbProvider.SQLProvider) 
        //        _query.RemoteQueryFactory = new SQLFactory();
        //}
    }
}
