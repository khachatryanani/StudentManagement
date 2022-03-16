CREATE TABLE [dbo].[Departments]
(
	[DepartmentId] INT NOT NULL IDENTITY(10,1),
	[Title] NVARCHAR(20) NOT NULL,
	CONSTRAINT PK_DepartmentId PRIMARY KEY (DepartmentId)
)
