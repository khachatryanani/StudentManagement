using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Data
{
    public static class DataRep
    {
        private static List<Student> _students = new List<Student>()
            {
                new Student(1, "Anne", "Aramyan", "anne.aramyan@gmail.com" ),
                new Student(2, "Karen", "Abgaryan", "karen.abgaryangmail.com" ),
                new Student(3, "Arsen", "Marmaryan", "arsen.marmaryan@gmail.com" ),
            };

        public static IEnumerable<Student> GetStudents() 
        {
            return _students;
        }

        public static Student GetStudent(int id )
        {
            return _students.FirstOrDefault(st => st.Id == id);
        }

        public static int AddStudent(Student student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);

            return student.Id;
        }

        public static void DeleteStudent(int id)
        {
            var studentToRemove = GetStudent(id);
            _students.Remove(studentToRemove);
        }
    }
}
