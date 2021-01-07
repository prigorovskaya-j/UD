CREATE TABLE [dbo].[Documents] (
[DocumentID] INT NOT NULL IDENTITY(1,1),
[InventoryName] CHAR (10) NOT NULL,
[DurationOfUse] INT NOT NULL,
[DateUsedFrom] DATE NOT NULL,
[DateUsedTo] DATE NULL,
[Reason] TEXT NULL,
PRIMARY KEY CLUSTERED ([DocumentID] ASC)
);