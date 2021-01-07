CREATE TABLE [dbo].[Inventarizations] (
[InventarizationID] INT NOT NULL IDENTITY(1,1),
[InventarizationDate] DATE NOT NULL,
[VerifierID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([InventarizationID] ASC),
FOREIGN KEY ([VerifierID]) REFERENCES [dbo].[Verifiers] ([VerifierID])
ON DELETE CASCADE ON UPDATE CASCADE
);