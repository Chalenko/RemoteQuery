using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Models
{
    public class Credentials
    {
        //public IAuthenticationType ConnectionType { get; set; } = AuthenticationType.WindowsAuthenticationType;
        public string UserName { get; set; } = "User";// string.Empty;
        public string Password { get; set; } = "Passs";// string.Empty;
    }
}
