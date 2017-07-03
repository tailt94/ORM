using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Factories
{
    class OleDbFactory :  DbFactory
    {
        public override DbConnection GetConnection()
        {
            return new OleDbConnection();
        }

        public override DbCommand GetCommand()
        {
            return new OleDbCommand();
        }

        public override DbParameter GetParam()
        {
            return new OleDbParameter();
        }
    }
}
