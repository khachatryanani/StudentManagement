CREATE PROCEDURE [dbo].[UpdateUser]
	@id int = 0,
	@firstname varchar(20),
	@lastname varchar(30),
	@email nchar(50),
	@imageUrl varchar(2048)
AS
	UPDATE Users
	SET FirstName = @firstname, LastName = @lastname, Email = @email, ImageURL = @imageUrl
	WHERE Users.Id = @id

RETURN 
