using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteQuery.Utils
{
    public static class EmumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        public static string ToString<T>(this IEnumerable<T> items)
        {
            StringBuilder result = new StringBuilder("");

            if (items.Any())
            {
                IEnumerator<T> enumerator = items.GetEnumerator();
                result.Append(enumerator.Current.ToString());
                while (enumerator.MoveNext())
                {
                    result.AppendFormat("; {0}", enumerator.Current.ToString());
                }
                //result.Append(".");
            }
            return result.ToString();
        }

        public static System.Data.DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            Type t = typeof(T);
            System.Reflection.PropertyInfo[] pia = t.GetProperties();
            //Create the columns in the DataTable
            foreach (System.Reflection.PropertyInfo pi in pia)
            {
                if ((pi.PropertyType.IsGenericType))
                {
                    Type typeOfColumn = pi.PropertyType.GetGenericArguments()[0];
                    dt.Columns.Add(pi.Name, typeOfColumn);
                }
                else
                    dt.Columns.Add(pi.Name, pi.PropertyType);
            }
            //Populate the table
            foreach (T item in items)
            {
                System.Data.DataRow dr = dt.NewRow();
                dr.BeginEdit();
                foreach (System.Reflection.PropertyInfo pi in pia)
                {
                    dr[pi.Name] = pi.GetValue(item, null);
                }
                dr.EndEdit();
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
