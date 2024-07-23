using RemoteQuery.Model;
using System;
using System.Text;
using System.Xml.Linq;

namespace RemoteQuery.SQL
{
    internal class SQLConnectionStringBuilder : IConnectionStringBuilder
    {
        private readonly string _baseConnectionString = "Data Source={0}; Initial Catalog={1}; Timeout=60000;";
        private readonly string _baseIntegratedSecurityPath = "Integrated Security = {0);";
        private readonly string _baseCredentialPath = "User ID={0}; Password={1};";

        private SQLConnectionString _connectionString;

        public SQLConnectionStringBuilder(SQLConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public string BuildConnectionString()
        {
            var strBuilder = new StringBuilder(GetBasePath());
            if (_connectionString.ConnectionType == AuthenticationType.WindowsAuthenticationType)
                strBuilder = strBuilder
                    .Append("; ")
                    .Append(GetIntegratedSecurityPath());
            if (_connectionString.ConnectionType == AuthenticationType.NativeAuthenticationType)
                strBuilder = strBuilder
                    .Append("; ")
                    .Append(GetCredentialPath());
            return strBuilder.ToString();
        }

        public string GetBasePath()
        {
            return string.Format(_baseConnectionString, _connectionString.ServerName, _connectionString.DBName);
        }

        public string GetIntegratedSecurityPath()
        {
            return string.Format(_baseIntegratedSecurityPath, bool.TrueString);
        }

        public string GetCredentialPath()
        {
            return string.Format(_baseCredentialPath, _connectionString.Credentials.UserName, _connectionString.Credentials.Password);
        }
    }
}