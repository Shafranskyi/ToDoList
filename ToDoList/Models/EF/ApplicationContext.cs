using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ToDoList.Models.Entities;

namespace ToDoList.Models.EF
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}