CREATE PROCEDURE [dbo].[UpdateUser]
	@id int = 0,
	@firstname varchar(20),
	@lastname varchar(30),
	@email nchar(50)
AS
	UPDATE Users
	SET FirstName = @firstname, LastName = @lastname, Email = @email
	WHERE Users.Id = @id

RETURN 
