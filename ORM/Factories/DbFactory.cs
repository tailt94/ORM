using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Factories
{
    abstract class DbFactory
    {
        public abstract DbConnection GetConnection();
        public abstract DbCommand GetCommand();
        public abstract DbParameter GetParam();
    }
}
