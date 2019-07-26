using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ToDoList.Models.Attributes;

namespace ToDoList.Models.MVC
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public MVCStatus MVCStatus { get; set; }
        
        public SelectList MyListPriorities { get; set; }
        public SelectList MyListCategories { get; set; }
    }
}