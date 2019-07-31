using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDoList.Models.Entities;

namespace ToDoList.Models.Attributes
{
    internal class PasswordEqualPasswordConfirmed : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = (validationContext.ObjectInstance as RegisterModel).Password;
            var passwordconfirm = (validationContext.ObjectInstance as RegisterModel).PasswordConfirm;
            var res = password != passwordconfirm ? new ValidationResult("Password and PasswordConfirm are not equal!") : null;
            return res;
        }
    }
}