using Microsoft.EntityFrameworkCore;

namespace SigletonApp
{
    class AppContext :DbContext
    {
        private static AppContext instance;
        public DbSet<DbItem> Items { get; set; }
        private AppContext():base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=mydb.db");            
        }        
        public static AppContext GetInstance()
        {
            if (instance==null)
            {
                instance = new AppContext();
            }
            return instance;
        }
    }    
}