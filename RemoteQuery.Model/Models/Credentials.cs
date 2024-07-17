using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Models
{
    public class Credentials
    {
        public ConnectionStringType ConnectionType { get; set; } = ConnectionStringType.WindowsConnectionStringType;
        public string UserName { get; set; } = "User";// string.Empty;
        public string Password { get; set; } = "Passs";// string.Empty;
    }
}
