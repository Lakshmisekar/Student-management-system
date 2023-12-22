using Student_management_system.Models.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Student
{
    public class Student:IAttendable
    {
        public int Id { get; set; }

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
        public virtual ICollection<Attendance> Attendances { get; set; }

        public bool MarkAttendance(bool isPresent)
        {
            throw new NotImplementedException();
        }
    }
}
