CREATE TABLE [dbo].[Orders]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [IdOrganization] INT NULL, 
    [IdEmployer] INT NULL, 
    [Client] NVARCHAR(100) NULL, 
    CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([IdOrganization]) REFERENCES [Organizations]([Id]), 
    CONSTRAINT [FK_Orders_Employers] FOREIGN KEY ([IdEmployer]) REFERENCES [Employers]([Id]) 
)
