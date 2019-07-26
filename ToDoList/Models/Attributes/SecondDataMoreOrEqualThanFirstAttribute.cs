using System;
using System.ComponentModel.DataAnnotations;
using ToDoList.Models.MVC;

namespace ToDoList.Models.Attributes
{
    internal class SecondDataMoreOrEqualThanFirstAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDate = (validationContext.ObjectInstance as TaskModelPost).StartDate;
            var endDate = (validationContext.ObjectInstance as TaskModelPost).EndDate;
            var res = endDate < startDate ? new ValidationResult("EndDate must be more or equal than FirstDate") : null;
            return res;
        }
    }
}