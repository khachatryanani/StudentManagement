using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Student: User
    {
        public Department Department { get; set; } = new Department();

        public Student(int id, string fn, string ln, string email, string dep=""): base(id, fn, ln, email, "student", string.Empty)
        {
            this.Department.Name = dep;
        }

        public Student()
        {

        }
    }
}
