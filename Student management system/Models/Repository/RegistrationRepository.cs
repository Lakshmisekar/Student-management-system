using Student_management_system.Models.Context;
using Student_management_system.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly Studentcontext _context;

        public RegistrationRepository(Studentcontext context)
        {
            _context = context;
        }

        public Registration GetRegistration(string name)
        {
            return _context.Registrations.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Registration> GetAllRegistrations()
        {
            return _context.Registrations.ToList();
        }

        public void AddRegistration(Registration registration)
        {
            _context.Registrations.Add(registration);
            _context.SaveChanges();
        }

    }
}