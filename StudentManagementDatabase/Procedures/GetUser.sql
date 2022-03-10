CREATE PROCEDURE [dbo].[GetUser]
	@id int
AS
	SELECT *
	FROM Users
	WHERE Id = @id
RETURN 