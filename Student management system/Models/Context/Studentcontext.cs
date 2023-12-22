using Student_management_system.Models.Student;
using Student_management_system.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Context
{
    public class Studentcontext: DbContext
    {
        public Studentcontext():base("name=studentdbn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Studentcontext>());
        }
        public DbSet<Login.Login> logins { get; set; }
        public DbSet<Login.Registration> Registrations { get; set; }
        public DbSet<Student_management_system.Models.Student.Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
       
    }
}