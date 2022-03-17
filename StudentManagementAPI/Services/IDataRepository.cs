using StudentManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Services
{
    public interface IDataRepository
    {
        //Students
        public IEnumerable<Student> GetStudents();

        public Student GetStudent(int id);

        public int AddStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(int id);

        //Users
        public IEnumerable<User> GetUsers();

        public User GetUser(int id);

        public int AddUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(int id);

        //Department

        public IEnumerable<Department> GetDepartments();

        public Department GetDepartment(int id);

        public int AddDepartment(Department department);

        public void UpdateDepartment(Department department);

        // Course
        public int AddCourse(Course course);

        // Enrollment
        public void AddEnrollment(int profId, int depId, int courseId);

        //Records
        public void AddRecord(Record record);
        public IEnumerable<Record> GetStudentRecords(int studentId);

    }
}
