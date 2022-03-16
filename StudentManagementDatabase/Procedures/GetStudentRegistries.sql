CREATE PROCEDURE [dbo].[GetStudentRegistries]
	@studentId int = 0
AS
	SELECT *
	FROM Registries
	WHERE Registries.StudentId = @studentId
RETURN 0
