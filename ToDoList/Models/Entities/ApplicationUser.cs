using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoList.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }
        public ApplicationUser()
        {
        }
    }
}