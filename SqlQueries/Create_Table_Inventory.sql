CREATE TABLE [dbo].[Inventory] (
[InventoryID] INT NOT NULL,
[AuditoriumID] CHAR (10) NOT NULL,
[DocumentID] INT NOT NULL,
[CurrentState] CHAR (10) NOT NULL,
[Availability] TINYINT NOT NULL,
PRIMARY KEY CLUSTERED ([InventoryID] ASC),
FOREIGN KEY ([AuditoriumID]) REFERENCES [dbo].[Auditorium] ([AuditoriumID]) ON
DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY ([DocumentID]) REFERENCES [dbo].[Document] ([DocumentID]) ON
DELETE CASCADE ON UPDATE CASCADE
);