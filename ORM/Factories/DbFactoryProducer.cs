using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Factories
{
    /// <summary>
    /// Use this class to get suitable factory for dâtbase
    /// </summary>
    class DbFactoryProducer
    {
        public static DbFactory GetFactory(string dataSourceName)
        {
            switch (dataSourceName)
            {
                case "SQL":
                    return new SqlFactory();
                case "OLEDB":
                    return new OleDbFactory();
                default:
                    return null;
            }
        }
    }
}
