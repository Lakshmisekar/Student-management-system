using Student_management_system.Models.IRepository;
using Student_management_system.Models.Student;
using Student_management_system.Models.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System;
using System.Linq;

public class StudentController : Controller
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public ActionResult Details()
    {
        List<Student> students = _studentRepository.GetAllStudents().ToList();
        return View(students);
    }
    public ActionResult Home()
    {
        return View();
    }


    public ActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Register(StudentRegistrationViewModel studentViewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var studentEntity = new Student
                {
                    Name = studentViewModel.Name,
                    Email = studentViewModel.Email,
                    DOB = studentViewModel.DOB,
                    FatherName = studentViewModel.FatherName,
                    Native = studentViewModel.Native
                };

                _studentRepository.AddStudent(studentEntity);

                return RedirectToAction("Details");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(studentViewModel);
            }
        }

        return View(studentViewModel);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        Student student = _studentRepository.GetStudentById(id.Value);

        if (student == null)
        {
            return HttpNotFound();
        }

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Student student)
    {
        if (ModelState.IsValid)
        {
            _studentRepository.UpdateStudent(student);
            return RedirectToAction("Details");
        }

        return View(student);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        Student student = _studentRepository.GetStudentById(id.Value);

        if (student == null)
        {
            return HttpNotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        _studentRepository.DeleteStudent(id);
        return RedirectToAction("Details");
    }

    public ActionResult RegistrationSuccess()
    {
        return View();
    }
}
