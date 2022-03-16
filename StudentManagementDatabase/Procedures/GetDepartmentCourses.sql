CREATE PROCEDURE [dbo].[GetDepartmentCourses]
	@departmentId int
AS
	SELECT *
	FROM Enrollments
	WHERE Enrollments.DepartmentId = @departmentId
RETURN 0
