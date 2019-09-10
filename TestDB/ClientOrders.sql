CREATE TABLE [dbo].[ClientOrders]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdClient] UNIQUEIDENTIFIER NOT NULL, 
    [IdOrder] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_ClientOrders_Clients] FOREIGN KEY ([IdClient]) REFERENCES [Clients]([Id]), 
    CONSTRAINT [FK_ClientOrders_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders]([Id])
)
