namespace ToDoList.Migrations
{
    using global::ToDoList.Models.DB;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationContext context)
        {
            context.Priorities.AddRange(new List<Priority> {
                new Priority { Value = "Low" },
                new Priority { Value = "Medium" },
                new Priority { Value = "High" }
            });

            context.Categories.AddRange(new List<Category> {
                new Category { Value = "Buy" },
                new Category { Value = "Work" },
                new Category { Value = "Personal" }
            });

            context.Statuses.AddRange(new List<Status> {
                new Status { Value = "To Do" },
                new Status { Value = "Done" }
            });

            context.SaveChanges();
        }
    }
}
