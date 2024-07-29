using RemoteQuery.Model;
using System;
using System.Text;
using System.Xml.Linq;

namespace RemoteQuery.SQL
{
    public class SQLConnectionStringBuilder : IConnectionStringBuilder
    {
        private readonly string _baseConnectionString = "Data Source={0}; Initial Catalog={1}; Timeout=60000";
        private readonly string _baseIntegratedSecurityPath = "Integrated Security = {0}";
        private readonly string _baseCredentialPath = "User ID={0}; Password={1}";

        public string BuildConnectionString(IConnectionData connectionData)
        {
            var strBuilder = new StringBuilder(GetBasePath(connectionData));
            if (connectionData.ConnectionType == AuthenticationType.WindowsAuthenticationType)
                strBuilder = strBuilder
                    .Append("; ")
                    .Append(GetIntegratedSecurityPath(connectionData));
            if (connectionData.ConnectionType == AuthenticationType.NativeAuthenticationType)
                strBuilder = strBuilder
                    .Append("; ")
                    .Append(GetCredentialPath(connectionData));
            return strBuilder.ToString();
        }

        public string GetBasePath(IConnectionData connectionData)
        {
            return string.Format(_baseConnectionString, connectionData.ServerName, connectionData.DBName);
        }

        public string GetIntegratedSecurityPath(IConnectionData connectionData)
        {
            return string.Format(_baseIntegratedSecurityPath, bool.TrueString);
        }

        public string GetCredentialPath(IConnectionData connectionData)
        {
            return string.Format(_baseCredentialPath, connectionData.Credentials.UserName, connectionData.Credentials.Password);
        }
    }
}