using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery
{
    public interface IConnectionString
    {
        string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
    }

    public abstract class ConnectionString : IConnectionString
    {
        protected readonly string _ConnectionString;

        public string ConnectionStringDisplayField { get; protected set; }

        public string ServerName { get; set; }
        public string DBName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public ConnectionString(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public abstract string GetConnectionString(string serverName, string dbName, string userName, string userPassword);
    }

    public class SQLConnectionString : ConnectionString
    {
        protected static IConnectionString _instance;

        private SQLConnectionString() : base("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Timeout=60000;") 
        {
            ConnectionStringDisplayField = "SQL"; 
        }

        public static IConnectionString Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SQLConnectionString();
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
           return string.Format(_ConnectionString, serverName, dbName, userName, userPassword);
        }
    }

    public class WindowsConnectionString : ConnectionString
    {
        protected static IConnectionString _instance;

        private WindowsConnectionString() : base("Data Source={0}; Initial Catalog={1}; Integrated Security=True; Timeout=60000;") 
        {
            ConnectionStringDisplayField = "Windows"; 
        }

        public static IConnectionString Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WindowsConnectionString();
                return _instance;
            }
        }

        public override string GetConnectionString(string serverName, string dbName, string userName, string userPassword)
        {
            return string.Format(_ConnectionString, serverName, dbName);
        }
    }
}
