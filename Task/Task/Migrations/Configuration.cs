namespace Task.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Task.Models.DbContextSchool>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Task.Models.DbContextSchool context)
        {
            context.Teachers.AddOrUpdate(
            c => c.Name, // Avoid duplicate insertions by checking if the name exists
            new Teacher { Name = "Suha" },
            new Teacher { Name = "Books" },
            new Teacher { Name = "Clothing" }
);
        }
    }
}
