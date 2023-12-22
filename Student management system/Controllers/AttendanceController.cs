using Student_management_system.Models.Context;
using Student_management_system.Models.Interface;
using Student_management_system.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_management_system.Controllers
{
   
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly Studentcontext _context = new Studentcontext();


        //public AttendanceController(IAttendanceService attendanceService)
        //{
        //    _attendanceService = attendanceService;
        //}

        public AttendanceController(IAttendanceService attendanceService, IAttendanceRepository attendanceRepository)
        {
            _attendanceService = attendanceService;
            _attendanceRepository = attendanceRepository;
        }



        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            var attendances = _attendanceRepository.GetAllAttendances();

            foreach (var student in students)
            {
                student.Attendances = attendances.Where(a => a.StudentId == student.Id).ToList();
            }

            return View(students);
        }
        [HttpPost]
        public JsonResult MarkAttendance(int studentId, bool isPresent)
        {
            var success = _attendanceRepository.MarkAttendance(studentId, isPresent);

            if (success)
            {
                return Json(new { success = true, message = "Attendance marked successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Error marking attendance." });
            }
        }

        //// GET: Attendance
        //public ActionResult Index()
        //{
        //    var students = _context.Students.ToList();
        //    return View(students);
        //}


       

        //[HttpPost]
        //public JsonResult MarkAttendance(int studentId, bool isPresent)
        //{
        //    var success = _attendanceService.MarkAttendance(studentId, isPresent);

        //    if (success)
        //    {
        //        return Json(new { success = true, message = "Attendance marked successfully." });
        //    }
        //    else
        //    {
        //        return Json(new { success = false, message = "Error marking attendance." });
        //    }
        //}
    }

}