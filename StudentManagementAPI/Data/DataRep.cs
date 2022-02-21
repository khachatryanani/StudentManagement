using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Data
{
    public class DataRep : IDataRepository
    {
        // Data
        private readonly List<Student> _students = new List<Student>()
            {
                new Student(1, "Anne", "Aramyan", "anne.aramyan@gmail.com", 1 ),
                new Student(2, "Karen", "Abgaryan", "karen.abgaryan@gmail.com", 2 ),
                new Student(3, "Arsen", "Marmaryan", "arsen.marmaryan@gmail.com", 3 ),
            };

        private readonly List<Professor> _professors = new List<Professor>()
            {
                new Professor(4, "Zaven", "Hovakimyan", "zaven.hovakimyan@gmail.com" ),
                new Professor(5, "Armen", "Vardanyan", "armen.vardanyan@gmail.com" ),
                new Professor(6, "Samvel", "Martirosyan", "samvel.martirosyan@gmail.com"),
            };

        private readonly List<User> _users = new List<User>()
            {
                new User(1, "Anne", "Aramyan", "anne.aramyan@gmail.com", "student" ),
                new User(2, "Karen", "Abgaryan", "karen.abgaryan@gmail.com", "student" ),
                new User(3, "Arsen", "Marmaryan", "arsen.marmaryan@gmail.com", "student" ),
                new User(4, "Zaven", "Hovakimyan", "zaven.hovakimyan@gmail.com", "professor" ),
                new User(5, "Armen", "Vardanyan", "armen.vardanyan@gmail.com", "professor" ),
                new User(6, "Samvel", "Martirosyan", "samvel.martirosyan@gmail.com", "professor"),
            };

        private  readonly List<Department> _departments = new List<Department>()
            {
                new Department(1, "Physics" ),
                new Department(2, "Chemistry" ),
                new Department(3, "Information Technology" )
            };

        public DataRep()
        {

        }

        //Students
        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(st => st.Id == id);
        }

        public int AddStudent(Student student)
        {
            student.Id = _users.Count + 1;
            _students.Add(student);
            _users.Add(student);

            return student.Id;
        }

        public void UpdateStudent(Student student)
        {
            var studentToUpdate = GetStudent(student.Id);

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.Email = student.Email;
            studentToUpdate.DepartmentId = student.DepartmentId;
        }

        public void DeleteStudent(int id)
        {
            var studentToRemove = GetStudent(id);
            _students.Remove(studentToRemove);
            _users.Remove(studentToRemove);
        }

        //Users
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User GetUser(int id)
        {
            return _users.FirstOrDefault(st => st.Id == id);
        }

        public int AddUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);

            if (user.Role == "studnet") 
            {
                var student = new Student(user.Id, user.FirstName, user.LastName, user.Email);
                _students.Add(student);
            }

            if (user.Role == "professor")
            {
                var prof = new Professor(user.Id, user.FirstName, user.LastName, user.Email);
                _professors.Add(prof);
            }

            return user.Id;
        }

        public void UpdateUser(User user)
        {
            var userToUpdate = GetStudent(user.Id);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
        }

        public void DeleteUser(int id)
        {
            var userToRemove = GetUser(id);

            if (userToRemove.Role == "student") 
            {
                DeleteStudent(userToRemove.Id);
            }

            if (userToRemove.Role == "professor")
            {
                DeleteProfessor(userToRemove.Id);
            }
        }

        //Professors
        public IEnumerable<Professor> GetProfessors()
        {
            return _professors;
        }

        public Professor GetProfessor(int id)
        {
            return _professors.FirstOrDefault(pr => pr.Id == id);
        }

        public int AddProfessor(Professor professor)
        {
            professor.Id = _users.Count + 1;
            _professors.Add(professor);
            _users.Add(professor);

            return professor.Id;
        }

        public void UpdateProfessor(Professor professor)
        {
            var profToUpdate = GetStudent(professor.Id);

            profToUpdate.FirstName = professor.FirstName;
            profToUpdate.LastName = professor.LastName;
            profToUpdate.Email = professor.Email;
        }

        public void DeleteProfessor(int id)
        {
            var profToRemove = GetProfessor(id);
            _professors.Remove(profToRemove);
            _users.Remove(profToRemove);
        }

        //Department

        public IEnumerable<Department> GetDepartments()
        {
            return _departments;
        }

        public Department GetDepartment(int id)
        {
            return _departments.FirstOrDefault(dep => dep.DepartmentId == id);
        }

        public int AddDepartment(Department department)
        {
            department.DepartmentId = _departments.Count + 1;
            _departments.Add(department);

            return department.DepartmentId;
        }

        public void UpdateDepartment(Department department)
        {
            var depToUpdate = GetDepartment(department.DepartmentId);

            depToUpdate.Name = department.Name;
        }
    }
}
