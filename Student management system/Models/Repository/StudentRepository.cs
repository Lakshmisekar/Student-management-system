using Student_management_system.Models.Context;
using Student_management_system.Models.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Studentcontext _context;

        public StudentRepository(Studentcontext context)
        {
            _context = context;
        }

        public IEnumerable<Student.Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student.Student GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        public void AddStudent(Student.Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student.Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student.Student student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

      
    }
}