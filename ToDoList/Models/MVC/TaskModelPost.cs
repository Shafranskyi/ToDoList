using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ToDoList.Models.Attributes;

namespace ToDoList.Models.MVC
{
    public class TaskModelPost
    {
        [Required(ErrorMessage = "Description is Required")]
        public string Name { get; set; }

        [StringLength(40, MinimumLength = 5, ErrorMessage = "Description should be [5 40] symbols")]
        [Required(ErrorMessage = "Name is Required")]
        public string Text { get; set; }

        [BeginDateMoreOrEqualDateNow]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}")]
        [Required(ErrorMessage = "BeginDate is Required")]
        public DateTime StartDate { get; set; }

        [SecondDataMoreOrEqualThanFirst]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}")]
        [Required(ErrorMessage = "EndDate is Required")]
        public DateTime EndDate { get; set; }

        public MVCStatus Status { get; set; }
        
        [Required(ErrorMessage = "Priority is Required")]
        public string MyListPriorities { get; set; }
        
        [Required(ErrorMessage = "Category is Required")]
        public string MyListCategories { get; set; }
    }
}