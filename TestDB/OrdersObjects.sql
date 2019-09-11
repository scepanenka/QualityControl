CREATE TABLE [dbo].[OrdersObjects]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdOrder] UNIQUEIDENTIFIER NULL, 
    [IdObject] UNIQUEIDENTIFIER NULL, 
    CONSTRAINT [FK_OrdersObjects_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [FK_OrdersObjects_Objects] FOREIGN KEY ([IdObject]) REFERENCES [Objects]([Id])
)
