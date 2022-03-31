using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Professor: User
    {
        public Professor()
        {

        }
        public Professor(int id, string fn, string ln, string email): base(id, fn, ln, email, "professor", string.Empty )
        {
            Departments = new List<Department>();
            Courses = new List<Course>();
            Students = new List<User>();
        }

        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }
        public List<User> Students { get; set; }
    }
}
