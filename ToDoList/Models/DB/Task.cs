using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.DB
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Category Category { get; set; }
    }
}