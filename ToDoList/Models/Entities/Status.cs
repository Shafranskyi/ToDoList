using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.DB
{
    public class Status
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}