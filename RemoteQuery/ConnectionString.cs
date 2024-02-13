using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery
{
    public interface IConnectionString
    {
        string GetConnectionString();
    }

    public abstract class ConnectionString : IConnectionString
    {
        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public abstract string GetConnectionString();
    }

    public class SQLConnectionString : ConnectionString
    {
        public override string GetConnectionString()
        {
           return string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;", ServerName, DBName, UserName, UserPassword);
        }
    }

    public class WindowsConnectionString : ConnectionString
    {
        public override string GetConnectionString()
        {
            return string.Format("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Timeout=60000;", ServerName, DBName);
        }
    }
}
