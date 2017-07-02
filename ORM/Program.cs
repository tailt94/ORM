using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

using ORM.DataAccess;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionString connString = new ConnectionString.Builder()
                .DataSource("(local)")
                .DbName("testdb")
                .Id("admin")
                .Password("admin")
                .Build();
            SqlConnection conn =
                new SqlConnection(connString.ToString());
            SqlDataReader rdr = null;

            try
            {
                conn.Open();

                String insertString = "insert into Customers (id, name) values (21, 'Alex')";
                String selectString = "select * from Customers";
                String updateString = "UPDATE Customers SET name = 'Windy' WHERE id = 21";
                String deleteString = "DELETE FROM Customers WHERE id = 21";

                SqlCommand cmd = new SqlCommand(selectString, conn);

                // get query results
                rdr = cmd.ExecuteReader();
                //cmd.ExecuteNonQuery();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[1]);
                }
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }

            Console.Read();
        }
    }
}
