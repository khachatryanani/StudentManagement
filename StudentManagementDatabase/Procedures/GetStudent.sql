CREATE PROCEDURE [dbo].[GetStudent]
	@id int
AS
	SELECT Students.StudentId, Users.FirstName, Users.LastName, Users.Email, Departments.Title
	FROM  Students JOIN Users on Students.StudentId = Users.Id
				JOIN Departments ON Students.DepartmentId = Departments.DepartmentId
	WHERE Students.StudentId = @id

RETURN 
