using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Model
{
    public class Credentials : ICredentials
    {
        public string UserName { get; set; } = "User";
        public string Password { get; set; } = "Password";
    }
}
