using Student_management_system.Models.Context;
using Student_management_system.Models.Student;
using Student_management_system.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

public class StudentController : Controller
{
    private readonly Studentcontext _context;

    public StudentController()
    {
        _context = new Studentcontext();
    }

    public ActionResult Details()
    {
        List<Student> students = _context.Students.ToList();
        return View(students);
    }

    public ActionResult Register()
    {
        return View();
    }
    public ActionResult Home()
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

                _context.Students.Add(studentEntity);
                _context.SaveChanges();

               
                return RedirectToAction("RegistrationSuccess");
            }
            catch (Exception ex)
            {
               
                ModelState.AddModelError(string.Empty, "An error occurred while processing your request.");
                return View(ex.Message);
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

        Student student = _context.Students.Find(id);

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
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
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

        Student student = _context.Students.Find(id);

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
        Student student = _context.Students.Find(id);

        if (student == null)
        {
            return HttpNotFound();
        }

        _context.Students.Remove(student);
        _context.SaveChanges();
        return RedirectToAction("Details");
    }

   
    public ActionResult RegistrationSuccess()
    {
        return View();
    }
}
