using System.Data.Entity.Migrations;

namespace WikiTutorial.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WikiTutorial.EntityFramework.WikiTutorialDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WikiTutorial";
        }

        protected override void Seed(WikiTutorial.EntityFramework.WikiTutorialDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
