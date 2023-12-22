using Student_management_system.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_management_system.Models.Repository
{
    public interface IRegistrationRepository
    {
        Registration GetRegistration(string name);
        IEnumerable<Registration> GetAllRegistrations();
        void AddRegistration(Registration registration);
    }
}
