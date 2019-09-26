CREATE TABLE [dbo].[Documents]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Number] NVARCHAR(20) NULL, 
    [Date] DATETIME2 NULL, 
    [Type] INT NULL, 
    [Information] NVARCHAR(200) NULL, 
    [IssuingAuthority] NVARCHAR(200) NULL
)
