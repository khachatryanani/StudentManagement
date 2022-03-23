CREATE TABLE [dbo].[Records]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[StudentId] INT NOT NULL,
	[ProfessorId] INT NOT NULL,
	[CourseId] INT NOT NULL,
	[Grade] INT NOT NULL,
	CONSTRAINT PK_RegId PRIMARY KEY (Id),
	CONSTRAINT FK_RegStudent FOREIGN KEY ([StudentId]) REFERENCES Users(Id),
	CONSTRAINT FK_RegProfessor FOREIGN KEY ([ProfessorId]) REFERENCES Users(Id) ,
	CONSTRAINT FK_RegCourse FOREIGN KEY ([CourseId]) REFERENCES Courses(CourseId),
	CONSTRAINT CH_Grade CHECK (Grade > 0 AND Grade < 20)
)
