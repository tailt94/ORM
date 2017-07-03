using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Libs
{
    class Util
    {
        /// <summary>
        ///     Format string type for sql query
        /// </summary>
        /// <typeparam name="T">Primitive type</typeparam>
        /// <param name="value">Value to check whether it's a string</param>
        /// <returns></returns>
        public static string FormatSqlValue<T>(T value)
        {
            Type type = value.GetType();
            if (type == typeof(string) || type == typeof(String))
            {
                return ("'" + value + "'");
            }
            return value.ToString();
        }
    }
}
