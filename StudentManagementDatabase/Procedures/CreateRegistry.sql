CREATE PROCEDURE [dbo].[CreateRegistry]
	@studentId int = 0,
	@professorId int = 0,
	@courseId int,
	@grade int
AS
	INSERT INTO Registries(StudentId, ProfessorId, CourseId, Grade)
	VALUES (@studentId, @professorId, @courseId, @grade)

RETURN 0
