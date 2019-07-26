using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ToDoList.Models.DB
{
    public class DoContext : DbContext
    {
        public DoContext() 
            : base("DBConnection")
        {
            Database.SetInitializer(new InitializeDB());
        }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Priority> Priorities { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }
    }
}