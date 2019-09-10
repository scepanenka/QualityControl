﻿CREATE TABLE [dbo].[Orders]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY NONCLUSTERED DEFAULT NEWID(), 
    [IdOrganization] INT NOT NULL, 
    [IdEmployee] INT NOT NULL, 
    [DateReceipt] DATETIME2 NOT NULL, 
    [DateExecution] DATETIME2 NOT NULL, 
    [Number] NVARCHAR(12) NOT NULL, 
    CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([IdOrganization]) REFERENCES [Organizations]([Id]), 
    CONSTRAINT [FK_Orders_Employees] FOREIGN KEY ([IdEmployee]) REFERENCES [Employees]([Id]) 
)
