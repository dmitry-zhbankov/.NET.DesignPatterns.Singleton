using System;

namespace SigletonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContext appContext = AppContext.GetInstance();                  
            appContext.Database.EnsureCreated();
            appContext.Items.Add(new DbItem() { Content = "first item" });
            appContext.Items.Add(new DbItem() { Content = "second item" });
            var count = appContext.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);
            Console.WriteLine();
            Console.WriteLine("All items in database:");
            foreach (var item in appContext.Items)
            {
                Console.WriteLine(" - {0}", item.Content);
            }
            Console.WriteLine();
            AppContext appContext2 = AppContext.GetInstance();
            if (appContext==appContext2)
            {
                Console.WriteLine("Singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton failed, variables contain different instances.");
            }
            appContext.Database.EnsureCreated();
            appContext.Items.Add(new DbItem() { Content = "third item" });
            appContext.Items.Add(new DbItem() { Content = "fourth item" });
            count = appContext.SaveChanges();
            Console.WriteLine("{0} records saved to database", count);
            Console.WriteLine();
            Console.WriteLine("All items in database:");
            foreach (var item in appContext.Items)
            {
                Console.WriteLine(" - {0}", item.Content);
            }
            Console.ReadLine();
        }
    }
}