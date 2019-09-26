CREATE TABLE [dbo].[OrdersOperations]
(
	[OperationId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(), 
    [OrderId] UNIQUEIDENTIFIER NOT NULL, 
    [OperTypeId] INT NULL, 
    [Comment] NCHAR(200) NULL, 
    [ExecutorId] INT NULL, 
    CONSTRAINT [FK_OrdersOperations_Orders] FOREIGN KEY ([OperationId]) REFERENCES [Orders]([Id]) 
)
