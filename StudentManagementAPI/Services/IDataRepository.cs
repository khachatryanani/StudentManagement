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

        public void AddUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(int id);

        //Professors
        public IEnumerable<Professor> GetProfessors();

        public Professor GetProfessor(int id);

        public int AddProfessor(Professor professor);

        public void UpdateProfessor(Professor professor);

        public void DeleteProfessor(int id);

        //Department

        public IEnumerable<Department> GetDepartments();

        public Department GetDepartment(int id);

        public int AddDepartment(Department department);

        public void UpdateDepartment(Department department);
    }
}
