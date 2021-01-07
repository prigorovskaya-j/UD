CREATE TABLE [dbo].[List] (
[ListID] INT NOT NULL,
[AuditoriumID] CHAR (10) NOT NULL,
[InventarizationID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([ListID] ASC),
FOREIGN KEY ([AuditoriumID]) REFERENCES [dbo].[Auditorium] ([AuditoriumID]) ON
DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY ([InventarizationID]) REFERENCES [dbo].[Inventarization] ([InventarizationID]) ON
DELETE CASCADE ON UPDATE CASCADE
);