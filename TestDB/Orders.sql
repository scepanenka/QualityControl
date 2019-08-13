CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdOrganization] INT NULL, 
    [IdEmployee] INT NULL, 
    [Client] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([IdOrganization]) REFERENCES [Organizations]([Id]), 
    CONSTRAINT [FK_Orders_Employees] FOREIGN KEY ([IdEmployee]) REFERENCES [Employees]([Id]) 
)
