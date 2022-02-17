using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Professor
    {
        public int ProfId { get; set; }
        public int FirstName { get; set; }
        public int LastName { get; set; }
        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
    }
}
