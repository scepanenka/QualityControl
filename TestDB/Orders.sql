CREATE TABLE [dbo].[Orders]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(), 
    [OrganizationId] INT NOT NULL, 
    [EmployeeId] INT NOT NULL, 
    [DateReceipt] DATETIME2 NOT NULL, 
    [DateExecution] DATE NOT NULL, 
    [Number] NVARCHAR(12) NOT NULL, 
    CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([OrganizationId]) REFERENCES [Organizations]([Id]), 
    CONSTRAINT [FK_Orders_Employees] FOREIGN KEY ([EmployeeId]) REFERENCES [Employees]([Id]) 
)
