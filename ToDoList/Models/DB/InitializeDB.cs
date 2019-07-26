using System.Data.Entity;
using System.Collections.Generic;

namespace ToDoList.Models.DB
{
    internal class InitializeDB : DropCreateDatabaseAlways<DoContext>
    {
        protected override void Seed(DoContext context)
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