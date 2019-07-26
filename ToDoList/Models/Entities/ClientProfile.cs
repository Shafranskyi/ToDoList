namespace ToDoList.Models.Entities
{
    public class ClientProfile
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}