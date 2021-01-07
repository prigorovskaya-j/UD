CREATE TABLE [dbo].[Document] (
[DocumentID] INT NOT NULL,
[InventoryName] CHAR (10) NOT NULL,
[DurationOfUse] INT NOT NULL,
[DateUsedFrom] DATE NOT NULL,
[DateUsedTo] DATE NULL,
[Reason] TEXT NULL,
PRIMARY KEY CLUSTERED ([DocumentID] ASC)
);