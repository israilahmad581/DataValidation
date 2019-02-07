using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DataValida.Models
{

    public enum gender
    {
        Male,Female
    }
    public class EmpDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Name should be 10 to 5 char",MinimumLength =5)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int Salary { get; set; }
        public gender Gender { get; set; }
    }
}