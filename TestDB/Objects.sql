CREATE TABLE [dbo].[Objects]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdObjectType] INT NOT NULL, 
    [Address] VARCHAR(250) NOT NULL, 
    [IdAddress] UNIQUEIDENTIFIER NULL, 
    [InvNumber] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Objects_ObjectsTypes] FOREIGN KEY ([IdObjectType]) REFERENCES [ObjectsTypes]([Id])
)
