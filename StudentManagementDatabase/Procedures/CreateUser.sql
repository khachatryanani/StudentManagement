CREATE PROCEDURE [dbo].[CreateUser]
	@firstname varchar(20),
	@lastname varchar(30),
	@email nchar(50)
AS
	INSERT INTO Users (FirstName, LastName, Email)
	VALUES(@firstname, @lastname, @email)

RETURN 
