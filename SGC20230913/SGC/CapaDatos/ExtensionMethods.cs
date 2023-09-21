using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CapaDatos
{
    public static class ExtensionMethods
    {
        public static object getDBNullOrValue<T>(this T val)
        {
            bool isDbNull;
            Type t = typeof(T);

            if (Nullable.GetUnderlyingType(t) != null)
                isDbNull = EqualityComparer<T>.Default.Equals(default(T), val);
            else if (t.IsValueType)
                isDbNull = false;
            else
                isDbNull = val == null;

            return isDbNull ? DBNull.Value : (object)val;
        }

        public static M getNullOrValue<M, T>(this T value)
        {
            Type m = typeof(M);

            if ((Object)value == DBNull.Value || value == null)
            {
                return default(M);
            }

            return (M)Convert.ChangeType(value, m);
        }

        public static T ChangeType<T>(object value)
        {
            return (T)ChangeType(typeof(T), value);
        }

        public static object ChangeType(Type t, object value)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);
            return tc.ConvertFrom(value);
        }
    }
}
