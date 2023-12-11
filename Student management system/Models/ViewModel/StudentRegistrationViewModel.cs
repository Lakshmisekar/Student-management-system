using System;
using System.ComponentModel.DataAnnotations;

namespace Student_management_system.Models.ViewModel
{
    public class StudentRegistrationViewModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Father's Name is required")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Native place is required")]
        public string Native { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
