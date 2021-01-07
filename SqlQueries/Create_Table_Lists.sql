CREATE TABLE [dbo].[Lists] (
[ListID] INT NOT NULL IDENTITY(1,1),
[AuditoriumID] INT NOT NULL,
[InventarizationID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([ListID] ASC),
FOREIGN KEY ([AuditoriumID]) REFERENCES [dbo].[Auditories] ([AuditoriumID]) ON
DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY ([InventarizationID]) REFERENCES [dbo].[Inventarizations] ([InventarizationID]) ON
DELETE CASCADE ON UPDATE CASCADE
);