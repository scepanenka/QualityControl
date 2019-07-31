CREATE TABLE [dbo].[Employers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Surname] NVARCHAR(100) NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Patronymic] NVARCHAR(100) NULL
)
