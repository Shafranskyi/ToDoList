using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Models.MVC;

namespace ToDoList.Models.Attributes
{
    internal class BeginDateMoreOrEqualDateNowAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDate = (validationContext.ObjectInstance as TaskModelPost).StartDate;
            var timeNow = DateTime.Now.Date;
            
            var IsToDo = timeNow > startDate;
            var res = IsToDo ? new ValidationResult("BeginDate must be more or equal than current Date") : null;

            return res;
        }
    }
}