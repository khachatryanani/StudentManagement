﻿CREATE PROCEDURE [dbo].[CreateUser]
	@firstname varchar(20),
	@lastname varchar(30),
	@email nchar(50),
	@role nchar(50),
	@imageUrl varchar(2048),

	@id int output
AS
	INSERT INTO Users (FirstName, LastName, Email, [Role], ImageURL)
	VALUES(@firstname, @lastname, @email, @role, @imageUrl)

	 SET @id=SCOPE_IDENTITY()
     RETURN  @id
RETURN 
