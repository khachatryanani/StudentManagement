using StudentManagementAPI.Models;
using StudentManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementAPI.Data
{
    public class DataRep : IDataRepository
    {
        private readonly string connectionString;

        public DataRep(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Data
        private readonly List<Student> _students = new List<Student>()
            {
                new Student(1, "Anne", "Aramyan", "anne.aramyan@gmail.com", "1" ),
                new Student(2, "Karen", "Abgaryan", "karen.abgaryan@gmail.com", "2" ),
                new Student(3, "Arsen", "Marmaryan", "arsen.marmaryan@gmail.com", "3" ),
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

        private readonly List<Department> _departments = new List<Department>()
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
            //return _students;
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStudents]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var students = new List<Student>();
                        if (reader.HasRows)
                        {
                            int stdId = reader.GetOrdinal("StudentId");
                            int stdFName = reader.GetOrdinal("FirstName");
                            int stdLName = reader.GetOrdinal("LastName");
                            int stdEmail = reader.GetOrdinal("Email");
                            int stdDep = reader.GetOrdinal("Department");


                            while (reader.Read())
                            {
                                students.Add(
                                    new Student
                                    {
                                        Id = reader.GetInt32(stdId),
                                        FirstName = reader.GetString(stdFName),
                                        LastName = reader.GetString(stdLName),
                                        Email = reader.GetString(stdEmail),
                                        Department = new Department() { Name = reader.GetString(stdDep) },
                                    });
                            }
                        }

                        return students;
                    }
                }
            }
        }

        public Student GetStudent(int id)
        {
            //return _students.FirstOrDefault(st => st.Id == id);
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStudent]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var student = new Student();
                        if (reader.HasRows)
                        {
                            int stdId = reader.GetOrdinal("StudentId");
                            int stdFName = reader.GetOrdinal("FirstName");
                            int stdLName = reader.GetOrdinal("LastName");
                            int stdEmail = reader.GetOrdinal("Email");
                            int stdDep = reader.GetOrdinal("Department");

                            student.Id = reader.GetInt32(stdId);
                            student.FirstName = reader.GetString(stdFName);
                            student.LastName = reader.GetString(stdLName);
                            student.Email = reader.GetString(stdEmail);
                            student.Department.Name = reader.GetString(stdDep);
                        }

                        return student;
                    }
                }
            }
        }

        public int AddStudent(Student student)
        {
            //student.Id = _users.Count + 1;
            //_students.Add(student);
            //_users.Add(student);

            //return student.Id;
            student.Role = "student";
            student.Id = AddUser(student);

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateStudent]";

                    command.Parameters.Add("@studentId", SqlDbType.VarChar).Value = student.Id;
                    command.Parameters.Add("@departmentId", SqlDbType.VarChar).Value = student.Department.DepartmentId;
                   
                    command.ExecuteNonQuery();
                }
            }

            return student.Id;
        }

        public void UpdateStudent(Student student)
        {
            //var studentToUpdate = GetStudent(student.Id);

            //studentToUpdate.FirstName = student.FirstName;
            //studentToUpdate.LastName = student.LastName;
            //studentToUpdate.Email = student.Email;
            //studentToUpdate.DepartmentId = student.DepartmentId;
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
            // return _users;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetUsers]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var users = new List<User>();
                        if (reader.HasRows)
                        {
                            int userId = reader.GetOrdinal("Id");
                            int userFName = reader.GetOrdinal("FirstName");
                            int userLName = reader.GetOrdinal("LastName");
                            int userEmail = reader.GetOrdinal("Email");
                            int userRole = reader.GetOrdinal("Role");

                            while (reader.Read())
                            {
                                users.Add(
                                    new User
                                    {
                                        Id = reader.GetInt32(userId),
                                        FirstName = reader.GetString(userFName),
                                        LastName = reader.GetString(userLName),
                                        Email = reader.GetString(userEmail),
                                        Role = reader.GetString(userRole)
                                    });
                            }
                        }

                        return users;
                    }
                }
            }
        }
        public User GetUser(int id)
        {
            //return _users.FirstOrDefault(st => st.Id == id);
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetUser]";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var user = new User();
                        if (reader.HasRows)
                        {
                            int userId = reader.GetOrdinal("Id");
                            int userFName = reader.GetOrdinal("FirstName");
                            int userLName = reader.GetOrdinal("LastName");
                            int userEmail = reader.GetOrdinal("Email");

                            user.Id = reader.GetInt32(userId);
                            user.FirstName = reader.GetString(userFName);
                            user.LastName = reader.GetString(userLName);
                            user.Email = reader.GetString(userEmail);
                        }

                        return user;
                    }
                }
            }
        }
        public int AddUser(User user)
        {
            //user.Id = _users.Count + 1;
            //_users.Add(user);

            //if (user.Role == "studnet")
            //{
            //    var student = new Student(user.Id, user.FirstName, user.LastName, user.Email);
            //    _students.Add(student);
            //}

            //if (user.Role == "professor")
            //{
            //    var prof = new Professor(user.Id, user.FirstName, user.LastName, user.Email);
            //    _professors.Add(prof);
            //}

            //return user.Id;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateUser]";

                    command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = user.FirstName;
                    command.Parameters.Add("@lastname", SqlDbType.VarChar).Value = user.LastName;
                    command.Parameters.Add("@email", SqlDbType.NChar).Value = user.Email;
                    command.Parameters.Add("@role", SqlDbType.NChar).Value = user.Role;

                    command.ExecuteNonQuery();
                    return Convert.ToInt32( command.Parameters["@id"].Value);
                }
            }
        }

        public void UpdateUser(User user)
        {
            //var userToUpdate = GetStudent(user.Id);

            //userToUpdate.FirstName = user.FirstName;
            //userToUpdate.LastName = user.LastName;
            //userToUpdate.Email = user.Email;

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateUser]";

                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = user.Id;
                    command.Parameters.Add("@firstname", SqlDbType.VarChar).Value = user.FirstName;
                    command.Parameters.Add("@lastname", SqlDbType.VarChar).Value = user.LastName;
                    command.Parameters.Add("@email", SqlDbType.NChar).Value = user.Email;

                    command.ExecuteNonQuery();
                }
            }
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
