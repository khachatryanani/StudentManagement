using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Student(int id, string fn, string ln, string email)
        {
            this.Id = id;
            this.FirstName = fn;
            this.LastName = ln;
            this.Email = email;
        }

        public Student()
        {

        }
    }
}
