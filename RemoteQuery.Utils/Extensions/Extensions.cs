using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Utils
{
    public static class Extensions
    {
        public static object[] PropertiesToArray(this object obj)
        {
            object[] result = new object[obj.GetType().GetProperties().Count()];

            int i = 0;
            foreach (var item in obj.GetType().GetProperties())
            {
                result[i++] = item.GetValue(obj, null);
            }

            return result;
        }
    }
}
