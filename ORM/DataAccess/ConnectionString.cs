using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.DataAccess
{
    class ConnectionString
    {
        private string dataSource;
        private string dbName;
        private string id;
        private string password;

        public ConnectionString(string dataSource, string dbName, string id, string password)
        {
            this.dataSource = dataSource;
            this.dbName = dbName;
            this.id = id;
            this.password = password;
        }

        public string DataSource { get => dataSource; set => dataSource = value; }
        public string DbName { get => dbName; set => dbName = value; }
        public string Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            string result = "Data Source = " + dataSource + "; Initial Catalog = " + dbName + "; User ID = " + id + "; Password = " + password;
            return result;
        }

        public class Builder
        {
            private ConnectionString connString;

            public Builder()
            {
                connString = new ConnectionString("(local)", "", "", "");
            }

            public Builder DataSource(string dataSource)
            {
                connString.DataSource = dataSource;
                return this;
            }

            public Builder DbName(string databaseName)
            {
                connString.DbName = databaseName;
                return this;
            }

            public Builder Id(string id)
            {
                connString.Id = id;
                return this;
            }

            public Builder Password(string password)
            {
                connString.Password = password;
                return this;
            }

            public ConnectionString Build()
            {
                return connString;
            }
        }
    }
}
