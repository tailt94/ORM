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
using ORM.Expressions;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            //-----DEMO - INSERT
            //DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            //ConnectionString connString = new ConnectionString.Builder()
            //    .DataSource("(local)")
            //    .DbName("testdb")
            //    .Id("admin")
            //    .Password("admin")
            //    .Build();

            //DbAccess dbAccess = new DbAccess(factory);
            //dbAccess.OpenConnection(connString);

            //Customer customer = new Customer(69, "Trang", 25, "Ho Chi Minh");
            //Console.WriteLine(dbAccess.Insert(customer, "Customers"));
            //dbAccess.CloseConnection();


            //-----DEMO - UPDATE
            //DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            //ConnectionString connString = new ConnectionString.Builder()
            //    .DataSource("(local)")
            //    .DbName("testdb")
            //    .Id("admin")
            //    .Password("admin")
            //    .Build();

            //DbAccess dbAccess = new DbAccess(factory);
            //dbAccess.OpenConnection(connString);

            //Customer customer = new Customer(111, "Trinity", 33, "New York");
            //Expression exp = new SimpleExpression<string, string>("name", "Lam", Expression.LIKE);
            //Console.WriteLine(dbAccess.Update(customer, "Customers", exp));
            //dbAccess.CloseConnection();


            //-----DEMO - DELETE
            //DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            //ConnectionString connString = new ConnectionString.Builder()
            //    .DataSource("(local)")
            //    .DbName("testdb")
            //    .Id("admin")
            //    .Password("admin")
            //    .Build();

            //DbAccess dbAccess = new DbAccess(factory);
            //dbAccess.OpenConnection(connString);

            //Expression exp = new SimpleExpression<string, int>("ID", 69, Expression.EQUAL);
            //Console.WriteLine(dbAccess.Delete("Customers", exp));
            //dbAccess.CloseConnection();


            //-----DEMO - SELECT
            DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            ConnectionString connString = new ConnectionString.Builder()
                .DataSource("(local)")
                .DbName("testdb")
                .Id("admin")
                .Password("admin")
                .Build();

            DbAccess dbAccess = new DbAccess(factory);
            dbAccess.OpenConnection(connString);

            List<Customer> list = dbAccess.Select<Customer>("Customers");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            dbAccess.CloseConnection();

            Console.ReadKey();
        }
    }
}
