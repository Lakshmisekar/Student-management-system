using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_management_system.Models.Login
{
    public class Login
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public int Password {  get; set; }
    }
}