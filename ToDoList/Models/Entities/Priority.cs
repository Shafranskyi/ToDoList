using System.Collections.Generic;

namespace ToDoList.Models.DB
{
    public class Priority
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}