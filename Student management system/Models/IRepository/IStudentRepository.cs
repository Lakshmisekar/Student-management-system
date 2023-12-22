using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_management_system.Models.IRepository
{
    public interface IStudentRepository
    {
        IEnumerable<Student.Student> GetAllStudents();
        Student.Student GetStudentById(int id);
        void AddStudent(Student.Student student);
        void UpdateStudent(Student.Student student);
        void DeleteStudent(int id);
    }
}
