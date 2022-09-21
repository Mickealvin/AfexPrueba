using System;
using System.Data.Entity;
using System.Linq;

namespace AfexPrueba.Model
{
    public class AfexDbContext : DbContext
    {
        // Your context has been configured to use a 'AfexDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AfexPrueba.Model.AfexDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AfexDbContext' 
        // connection string in the application configuration file.
        public AfexDbContext()
            : base("name=AfexDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Videos> Videos { get; set; }
    }

    
}