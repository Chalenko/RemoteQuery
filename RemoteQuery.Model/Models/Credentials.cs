using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
