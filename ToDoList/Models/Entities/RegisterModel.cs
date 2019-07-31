using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToDoList.Models.Attributes;

namespace ToDoList.Models.Entities
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [PasswordEqualPasswordConfirmed]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}