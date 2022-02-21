using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public Department()
        {

        }

        public Department(int id, string name )
        {
            this.DepartmentId = id;
            this.Name = name;

            Courses = new List<Course>();
            Students = new List<User>();
            Professors = new List<User>();
        }

        public List<Course> Courses { get; set; }
        public List<User> Students { get; set; }
        public List<User> Professors { get; set; }
    }
}
