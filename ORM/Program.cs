using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using ORM.DataAccess;
using ORM.Factories;
using ORM.Examples;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            ConnectionString connString = new ConnectionString.Builder()
                .DataSource("(local)")
                .DbName("testdb")
                .Id("admin")
                .Password("admin")
                .Build();

            DbAccess dbAccess = new DbAccess(factory);
            dbAccess.OpenConnection(connString); 

            Customer customer = new Customer(69, "Trang");
            Console.WriteLine(dbAccess.Insert(customer, "Customers"));
            dbAccess.CloseConnection();
            
            Console.Read();
        }
    }
}
