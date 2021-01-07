CREATE TABLE [dbo].[Inventories] (
[InventoryID] INT NOT NULL IDENTITY(1,1),
[AuditoriumID] CHAR (10) NOT NULL,
[DocumentID] INT NOT NULL,
[CurrentState] CHAR (10) NOT NULL,
[Availability] TINYINT NOT NULL,
PRIMARY KEY CLUSTERED ([InventoryID] ASC),
FOREIGN KEY ([AuditoriumID]) REFERENCES [dbo].[Auditories] ([AuditoriumID]) ON
DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Documents] ([DocumentID]) ON
DELETE CASCADE ON UPDATE CASCADE
);