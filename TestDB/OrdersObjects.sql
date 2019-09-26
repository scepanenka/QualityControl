CREATE TABLE [dbo].[OrdersObjects]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [OrderId] UNIQUEIDENTIFIER NULL, 
    [ObjectId] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_OrdersObjects_Orders] FOREIGN KEY ([OrderId]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [FK_OrdersObjects_Objects] FOREIGN KEY ([ObjectId]) REFERENCES [Objects]([Id])
)
