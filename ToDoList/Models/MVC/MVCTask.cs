using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models.MVC
{
    public class MVCTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }        
        public string Priority { get; set; }
        public string Category { get; set; }
    }
}