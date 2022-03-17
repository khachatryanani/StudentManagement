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
            //
        }

        public void DeleteStudent(int id)
        {
            //
        }

        //Users
        public IEnumerable<User> GetUsers()
        {
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
            //
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

        // Courses
        public int AddCourse(Course course)
        { 
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateCourse]";

                    command.Parameters.Add("@title", SqlDbType.VarChar).Value = course.Title;
                   
                    command.ExecuteNonQuery();
                    return Convert.ToInt32(command.Parameters["@id"].Value);
                }
            }
        }


        // Enrollments
        public void AddEnrollment(int profId, int depId, int courseId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateEnrollment]";

                    command.Parameters.Add("@professorId", SqlDbType.VarChar).Value = profId;
                    command.Parameters.Add("@departmentId", SqlDbType.VarChar).Value = depId;
                    command.Parameters.Add("@courseId", SqlDbType.VarChar).Value = courseId;

                    command.ExecuteNonQuery();
                }
            }
        }

        // Records
        public void AddRecord(Record record)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateRecord]";

                    command.Parameters.Add("@studentId", SqlDbType.VarChar).Value = record.StudentId;
                    command.Parameters.Add("@professorId", SqlDbType.VarChar).Value = record.ProfessorId;
                    command.Parameters.Add("@courseId", SqlDbType.VarChar).Value = record.CourseId;
                    command.Parameters.Add("@c", SqlDbType.VarChar).Value = record.Grade;

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Record> GetStudentRecords(int studentId) 
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStudentRecords]";
                    command.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var records = new List<Record>();
                        if (reader.HasRows)
                        {
                            int stdId = reader.GetOrdinal("StudentId");
                            int profId = reader.GetOrdinal("ProfessorId");
                            int cId = reader.GetOrdinal("CourseId");
                            int grade = reader.GetOrdinal("Grade");

                            while (reader.Read())
                            {
                                records.Add(
                                    new Record
                                    {
                                        StudentId = reader.GetInt32(stdId),
                                        ProfessorId = reader.GetInt32(profId),
                                        CourseId = reader.GetInt32(cId),
                                        Grade = reader.GetInt32(grade)
                                    });
                            }
                        }

                        return records;
                    }
                }
            }
        }
    }
}
