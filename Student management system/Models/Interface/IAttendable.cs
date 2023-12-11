using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_management_system.Models.Interface
{
    public interface IAttendable
    {
        bool MarkAttendance(bool isPresent);
    }

}
