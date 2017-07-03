using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Factories
{
    class SqlFactory : DbFactory
    {
        public override DbConnection GetConnection()
        {
            return new SqlConnection();
        }

        public override DbCommand GetCommand()
        {
            return new SqlCommand();
        }

        public override DbParameter GetParam()
        {
            return new SqlParameter();
        }
    }
}
