using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using ToDoList.Models.DB;

namespace ToDoList.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }

        public virtual ICollection<Category> Categories { get; set; }
    }
}