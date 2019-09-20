CREATE TABLE [dbo].[OrdersQuality]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [IdOrder] UNIQUEIDENTIFIER NOT NULL, 
    [IdVerifier] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL  DEFAULT GETDATE(), 
    [Result] NCHAR(10) NULL, 
    CONSTRAINT [FK_OrdersQuality_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders]([Id]), 
    CONSTRAINT [FK_OrdersQuality_Employees] FOREIGN KEY ([IdVerifier]) REFERENCES [Employees]([Id])
)
