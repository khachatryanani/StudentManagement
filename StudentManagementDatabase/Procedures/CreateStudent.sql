CREATE PROCEDURE [dbo].[CreateStudent]
	@studentId int,
	@departmentId int

AS
	INSERT INTO Students(StudentId, DepartmentId)
	VALUES(@studentId, @departmentId)

RETURN 

