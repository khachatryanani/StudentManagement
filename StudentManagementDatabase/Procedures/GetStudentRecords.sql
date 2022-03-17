CREATE PROCEDURE [dbo].[GetStudentRecords]
	@studentId int = 0
AS
	SELECT *
	FROM Records
	WHERE Records.StudentId = @studentId
RETURN 0
