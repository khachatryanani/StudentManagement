CREATE PROCEDURE [dbo].[CreateEnrollment]
	@professorId int,
	@departmentId int,
	@courseId int

AS
	INSERT INTO Enrollments(ProfessorId, DepartmentId, CourseId)
	VALUES(@professorId, @departmentId, @courseId)

RETURN 