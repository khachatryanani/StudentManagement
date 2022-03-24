CREATE PROCEDURE [dbo].[DeleteUser]
	@id int
AS
	DELETE FROM Users
	WHERE Users.Id = @id
RETURN 0
