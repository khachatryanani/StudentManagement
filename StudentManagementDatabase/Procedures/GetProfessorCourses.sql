CREATE PROCEDURE [dbo].[GetProfessorCourses]
	@professorId int = 0
AS
	SELECT *
	FROM Enrollments 
	WHERE Enrollments.ProfessorId = @professorId
RETURN 0
