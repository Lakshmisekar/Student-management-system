using Student_management_system.Models.Context;
using Student_management_system.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Student
{
    public class AttendanceService : IAttendanceService
    {
        private readonly Studentcontext _context;

        public AttendanceService(Studentcontext context)
        {
            _context = context;
        }

        public bool MarkAttendance(int studentId, bool isPresent)
        {
            try
            {
                var student = _context.Students.Find(studentId);

                if (student != null)
                {
                    var attendance = new Attendance
                    {
                        StudentId = studentId,
                        Date = DateTime.Now,
                        IsPresent = isPresent
                    };

                    _context.Attendances.Add(attendance);
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}