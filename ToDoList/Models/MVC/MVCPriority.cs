using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.MVC
{
    public class MVCPriority
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public ICollection<MVCTask> Tasks { get; set; }
    }
}