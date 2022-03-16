CREATE PROCEDURE [dbo].[CreateCourse]
	@title varchar(20),

	@courseid int output
AS
	INSERT INTO Courses (Title)
	VALUES(@title)

	 SET @courseid=SCOPE_IDENTITY()
     RETURN  @courseid
RETURN 
