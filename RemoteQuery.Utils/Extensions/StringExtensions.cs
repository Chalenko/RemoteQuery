using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Utils
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhitespace(this string text)
        {
            return text == null || text.Trim() == String.Empty;
        }
    }
}
