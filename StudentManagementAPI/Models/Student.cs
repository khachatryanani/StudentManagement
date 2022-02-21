using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Student: User
    {
        public int DepartmentId { get; set; }

        public Student(int id, string fn, string ln, string email, int dep = 0): base(id, fn, ln, email, "student")
        {
            this.DepartmentId = dep;
        }

        public Student()
        {

        }
    }
}
