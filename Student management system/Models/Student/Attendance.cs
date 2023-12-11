using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Student
{
    public class Attendance: Interface.IAttendable
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Attendance status is required")]
        public bool IsPresent { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public bool MarkAttendance(bool isPresent)
        {
            throw new NotImplementedException();
        }
    }
}