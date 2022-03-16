﻿CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY (1000,1) NOT NULL,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[Role] NVARCHAR(10) NOT NULL,
	CONSTRAINT PK_UserID PRIMARY KEY (Id),
	CONSTRAINT UQ_Email UNIQUE (Email),
	CONSTRAINT CH_Role CHECK ([Role] in ('Student', 'Professor', 'Other'))
)
