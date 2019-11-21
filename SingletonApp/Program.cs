using System;

namespace SingletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyConnection connection = MyConnection.GetInstance();

            string sqlQuery =
            @"CREATE TABLE IF NOT EXISTS Items(
            Id INTEGER PRIMARY KEY,
            Content TEXT NOT NULL
            );";
            Console.WriteLine($"Executing query \"{sqlQuery}\"");
            int res = connection.ExecuteQuery(sqlQuery);
            Console.WriteLine($"N={res}; N - number of rows inserted, updated, or deleted. -1 for SELECT statements. -2 for error", res);
            Console.WriteLine();

            sqlQuery = "INSERT INTO Items(Content) VALUES('first item')";
            Console.WriteLine($"Executing query \"{sqlQuery}\"");
            res = connection.ExecuteQuery(sqlQuery);
            Console.WriteLine($"N={res}; N - number of rows inserted, updated, or deleted. -1 for SELECT statements. -2 for error", res);
            Console.WriteLine();

            sqlQuery = "SELECT * FROM Items";
            Console.WriteLine($"Executing query \"{sqlQuery}\"");
            res = connection.ExecuteQuery(sqlQuery);
            Console.WriteLine($"N={res}; N - number of rows inserted, updated, or deleted. -1 for SELECT statements. -2 for error", res);
            Console.WriteLine();

            MyConnection connection2 = MyConnection.GetInstance();
            if (connection == connection2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }

            Console.WriteLine();
            connection.Dispose();
            Console.ReadLine();
        }
    }
}