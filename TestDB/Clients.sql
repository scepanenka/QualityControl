CREATE TABLE [dbo].[Clients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Surname] NVARCHAR(100) NOT NULL, 
    [Name] NVARCHAR(20) NULL, 
    [Patronymic] NVARCHAR(20) NULL, 
    [Address] NVARCHAR(200) NULL, 
    [PersonalNumber] NVARCHAR(20) NULL, 
    [PhoneNumber] CHAR(20) NULL, 
    [TypeClient] INT NULL, 
    [UNN] NCHAR(12) NULL, 
    [BothDate] DATETIME2 NULL, 
    [Information] NVARCHAR(500) NULL 
)
