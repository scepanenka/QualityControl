CREATE TABLE [dbo].[Objects]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ObjectTypeId] INT NOT NULL, 
    [Address] VARCHAR(250) NOT NULL, 
    [AddressId] UNIQUEIDENTIFIER NULL, 
    [InvNumber] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Objects_ObjectsTypes] FOREIGN KEY ([ObjectTypeId]) REFERENCES [ObjectsTypes]([Id])
)
