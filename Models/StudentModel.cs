using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Manager.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        [DisplayName("Id")]
        public int StudentId { get; set; }


        [Required(ErrorMessage = "Please enter name")]
        [DisplayName("Name")]
        [StringLength(50, ErrorMessage="Name cannot be longer than 50 characters")]
        public String StudentName { get; set; }


        [Required(ErrorMessage = "Please enter email address")]
        [DisplayName("Email")]
        [StringLength(50, ErrorMessage="Email cannot be longer than 50 characters")]
        [Remote("EmailExists", "Validate", HttpMethod = "POST", ErrorMessage = "email already exists.")]
        public String StudentEmail { get; set; }


        [Required(ErrorMessage = "Enter contact number")]
        [DisplayName("Contact")]
        [RegularExpression("^[0-9]+$", ErrorMessage ="Only numbers are allowed")]
        [Range(0, 9999999999, ErrorMessage="Contact no. longer then 10 numbers")]
        public long StudentContact { get; set; }
    }
}
