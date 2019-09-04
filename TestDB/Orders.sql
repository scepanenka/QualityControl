CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IdOrganization] INT NOT NULL, 
    [IdEmployee] INT NOT NULL, 
    [Client] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([IdOrganization]) REFERENCES [Organizations]([Id]), 
    CONSTRAINT [FK_Orders_Employees] FOREIGN KEY ([IdEmployee]) REFERENCES [Employees]([Id]) 
)
