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

            //Customer customer = new Customer(69, "Trang");
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

            //Customer customer = new Customer(112, "Trinity");
            //Expression exp = new SimpleExpression<string, string>("name", "Alex", Expression.LIKE);
            //Console.WriteLine(dbAccess.Update(customer, "Customers", exp));
            //dbAccess.CloseConnection();

            //-----DEMO - DELETE
            DbFactory factory = DbFactoryProducer.GetFactory("SQL");
            ConnectionString connString = new ConnectionString.Builder()
                .DataSource("(local)")
                .DbName("testdb")
                .Id("admin")
                .Password("admin")
                .Build();

            DbAccess dbAccess = new DbAccess(factory);
            dbAccess.OpenConnection(connString);

            Expression exp = new SimpleExpression<string, string>("name", "Ngoc", Expression.LIKE);
            Console.WriteLine(dbAccess.Delete("Customers", exp));
            dbAccess.CloseConnection();



            //Expression e1 = new SimpleExpression<string, int>("id", 5, Expression.GREATER_EQUAL);
            //Expression e2 = new SimpleExpression<string, string>("name", "Lan", Expression.EQUAL);
            //Expression ex = new ComplexExpression(e1, e2, Expression.OR);

            //Expression e3 = new SimpleExpression<string, int>("i", 21, Expression.LESS_THAN);
            //Expression ee = new ComplexExpression(e3, ex, Expression.AND);
            //Console.WriteLine(ee);

            Console.ReadKey();
        }
    }
}
