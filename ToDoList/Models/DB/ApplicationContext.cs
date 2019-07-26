using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoList.Models.Entities;

namespace ToDoList.Models.DB
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("DBConnection") { }

        internal static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public virtual DbSet<Task> Tasks { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Priority> Priorities { get; set; }

        public virtual DbSet<Status> Statuses { get; set; }
    }
}