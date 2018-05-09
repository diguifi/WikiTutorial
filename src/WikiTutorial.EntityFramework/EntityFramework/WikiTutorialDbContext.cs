using System.Data.Common;
using System.Data.Entity;
using Abp.EntityFramework;
using WikiTutorial.Entities.ProductEntity;

namespace WikiTutorial.EntityFramework
{
    public class WikiTutorialDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<Product> Products { get; set; }

        public WikiTutorialDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in WikiTutorialDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of WikiTutorialDbContext since ABP automatically handles it.
         */
        public WikiTutorialDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public WikiTutorialDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public WikiTutorialDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
