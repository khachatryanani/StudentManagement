CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL,
	[DepartmentId] INT,
	[Date] datetime2 NOT NULL,

	CONSTRAINT FK_Student FOREIGN KEY ([StudentId]) REFERENCES Users(Id) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Department FOREIGN KEY ([DepartmentId]) REFERENCES Departments([DepartmentId]) ON UPDATE CASCADE
)
