CREATE TABLE [ClientOrders] (
[Id] uniqueidentifier NOT NULL,
[IdClient] uniqueidentifier NOT NULL,
[IdOrder] uniqueidentifier NOT NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[ClientOrders]', RESEED, 0)
GO
ALTER TABLE [ClientOrders] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Clients] (
[Id] uniqueidentifier NOT NULL,
[Surname] nvarchar(100) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Name] nvarchar(20) COLLATE Cyrillic_General_CI_AS NULL,
[Patronymic] nvarchar(20) COLLATE Cyrillic_General_CI_AS NULL,
[Address] nvarchar(200) COLLATE Cyrillic_General_CI_AS NULL,
[PersonalNumber] nvarchar(20) COLLATE Cyrillic_General_CI_AS NULL,
[PhoneNumber] char(20) COLLATE Cyrillic_General_CI_AS NULL,
[TypeClient] int NULL,
[UNN] nchar(12) COLLATE Cyrillic_General_CI_AS NULL,
[BothDate] datetime2(7) NULL,
[Information] nvarchar(500) COLLATE Cyrillic_General_CI_AS NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Clients]', RESEED, 0)
GO
ALTER TABLE [Clients] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Employees] (
[Id] int NOT NULL IDENTITY(1,1),
[Surname] nvarchar(100) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Name] nvarchar(100) COLLATE Cyrillic_General_CI_AS NOT NULL,
[Patronymic] nvarchar(100) COLLATE Cyrillic_General_CI_AS NULL,
[IdPosition] int NOT NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Employees]', RESEED, 14)
GO
ALTER TABLE [Employees] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Objects] (
[Id] uniqueidentifier NOT NULL,
[IdObjectType] int NOT NULL,
[Address] varchar(250) COLLATE Cyrillic_General_CI_AS NOT NULL,
[IdAddress] uniqueidentifier NULL,
[InvNumber] nvarchar(50) COLLATE Cyrillic_General_CI_AS NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Objects]', RESEED, 0)
GO
ALTER TABLE [Objects] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [ObjectsTypes] (
[Id] int NOT NULL IDENTITY(1,1),
[Name] nvarchar(100) COLLATE Cyrillic_General_CI_AS NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[ObjectsTypes]', RESEED, 1)
GO
ALTER TABLE [ObjectsTypes] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Orders] (
[Id] uniqueidentifier NOT NULL DEFAULT (newid()),
[IdOrganization] int NOT NULL,
[IdEmployee] int NULL,
[DateReceipt] datetime2(7) NOT NULL DEFAULT (getdate()),
[DateExecution] date NOT NULL,
[Number] nvarchar(12) COLLATE Cyrillic_General_CI_AS NOT NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Orders]', RESEED, 0)
GO
ALTER TABLE [Orders] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [OrdersObjects] (
[Id] uniqueidentifier NOT NULL,
[IdOrder] uniqueidentifier NULL,
[IdObject] uniqueidentifier NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[OrdersObjects]', RESEED, 0)
GO
ALTER TABLE [OrdersObjects] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [OrdersQuality] (
[Id] uniqueidentifier NOT NULL,
[IdOrder] uniqueidentifier NOT NULL,
[IdVerifier] int NOT NULL,
[Date] datetime2(7) NOT NULL DEFAULT (getdate()),
[Result] nchar(10) COLLATE Cyrillic_General_CI_AS NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[OrdersQuality]', RESEED, 0)
GO
ALTER TABLE [OrdersQuality] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Organizations] (
[Id] int NOT NULL,
[Name] nvarchar(100) COLLATE Cyrillic_General_CI_AS NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Organizations]', RESEED, 0)
GO
ALTER TABLE [Organizations] SET ( LOCK_ESCALATION = TABLE )
GO

CREATE TABLE [Positions] (
[Id] int NOT NULL IDENTITY(1,1),
[Name] nvarchar(100) COLLATE Cyrillic_General_CI_AS NOT NULL,
PRIMARY KEY ([Id]) 
)
GO
DBCC CHECKIDENT (N'[Positions]', RESEED, 7)
GO
ALTER TABLE [Positions] SET ( LOCK_ESCALATION = TABLE )
GO


ALTER TABLE [ClientOrders] ADD CONSTRAINT [FK_ClientOrders_Clients] FOREIGN KEY ([IdClient]) REFERENCES [Clients] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [ClientOrders] ADD CONSTRAINT [FK_ClientOrders_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Employees] ADD CONSTRAINT [FK_Employees_Positions] FOREIGN KEY ([IdPosition]) REFERENCES [Positions] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Objects] ADD CONSTRAINT [FK_Objects_ObjectsTypes] FOREIGN KEY ([IdObjectType]) REFERENCES [ObjectsTypes] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Employees] FOREIGN KEY ([IdEmployee]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Organizations] FOREIGN KEY ([IdOrganization]) REFERENCES [Organizations] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrdersObjects] ADD CONSTRAINT [FK_OrdersObjects_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrdersObjects] ADD CONSTRAINT [FK_OrdersObjects_Objects] FOREIGN KEY ([IdObject]) REFERENCES [Objects] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrdersQuality] ADD CONSTRAINT [FK_OrdersQuality_Employees] FOREIGN KEY ([IdVerifier]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO
ALTER TABLE [OrdersQuality] ADD CONSTRAINT [FK_OrdersQuality_Orders] FOREIGN KEY ([IdOrder]) REFERENCES [Orders] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

