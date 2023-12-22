using Student_management_system.Models.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_management_system.Models.IRepository
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAllAttendances();
        bool MarkAttendance(int studentId, bool isPresent);
    }
}
