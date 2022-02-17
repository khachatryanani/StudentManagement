using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int Title { get; set; }
        public Department Department { get; set; }
        public Professor Professor { get; set; }
    }
}
