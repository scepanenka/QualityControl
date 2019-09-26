CREATE TABLE [dbo].[OperationsQuality]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [VerifierId] NCHAR(10) NOT NULL, 
    [QualityRate] INT NOT NULL, 
    [OperationId] UNIQUEIDENTIFIER NOT NULL, 
    [ControlTypeId] INT NOT NULL, 
    [Comment] NCHAR(100) NULL, 
    [QualityDocumentId] UNIQUEIDENTIFIER NULL
)
