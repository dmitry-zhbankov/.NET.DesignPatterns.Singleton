using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;

namespace SingletonApp
{
    class MyConnection: IDisposable
    {
        private static MyConnection instance;        
        private bool disposed = false;
        private static SqliteConnection connection;
        private MyConnection()
        {
            connection = new SqliteConnection(@"Data Source=mydb.db");
            connection.Open();            
        }
        public int ExecuteQuery(string sqlExpression)
        {
            if (instance!=null)
            {
                SqliteCommand command = new SqliteCommand(sqlExpression,connection);
                return command.ExecuteNonQuery();
            }
            return -2;
        }
        public static MyConnection GetInstance()
        {
            if (instance==null)
            {
                instance = new MyConnection();                
            }
            return instance;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    
                }
                connection?.Close();
                connection?.Dispose();
                disposed = true;
                Console.WriteLine("Object has disposed");
            }
        }
        ~MyConnection()
        {
            Dispose(false);
        }

    }    
}