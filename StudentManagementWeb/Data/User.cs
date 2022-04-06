namespace StudentManagementWeb.Data
{
    public class DepartmentMeri
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
        public string ImageUrl { get; set; }


    }
    public class GradeStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ProfessorId { get; set; }
        public int CourseId { get; set; }
        public int Grade { get; set; }

    }

   

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
    }

    

}
