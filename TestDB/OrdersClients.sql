CREATE TABLE [dbo].[OrdersClients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [ClientId] UNIQUEIDENTIFIER NOT NULL, 
    [OrderId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_OrdersClients_Clients] FOREIGN KEY ([ClientId]) REFERENCES [Clients]([Id]), 
    CONSTRAINT [FK_OrdersClients_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]) 
)
