using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SecureStudentManager.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Telephone { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date of Birth")]
        public DateTime DoB { get; set; }
        public bool Maried { get; set; }

        public int DepartmentID { get; set; }

        //  public bool isAdmin { get; set; }


    }
}