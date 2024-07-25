using RemoteQuery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.SQL
{
    public class SQLFactory : IDBRemoteQueryFactory
    {
        public IConnectionData CreateConnectionData()
        {
            return new SQLConnectionData();
        }
    }
}
