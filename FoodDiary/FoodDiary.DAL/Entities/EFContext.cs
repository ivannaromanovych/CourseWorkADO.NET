namespace FoodDiary.DAL.Entities
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EFContext : DbContext
    {
        // Your context has been configured to use a 'EFContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FoodDiary.DAL.Entities.EFContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EFContext' 
        // connection string in the application configuration file.
        public EFContext()
            : base("EFContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}