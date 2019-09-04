﻿CREATE TABLE [dbo].[Employees]
(
	[Id] INT NOT NULL IDENTITY , 
    [Surname] NVARCHAR(100) NOT NULL, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Patronymic] NVARCHAR(100) NULL, 
    [IdPosition] INT NOT NULL, 
    PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Employees_Positions] FOREIGN KEY ([IdPosition]) REFERENCES [Positions]([Id]) 
)
