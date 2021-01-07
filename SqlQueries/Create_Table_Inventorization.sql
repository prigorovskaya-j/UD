CREATE TABLE [dbo].[Inventarization] (
[InventarizationID] INT NOT NULL,
[InventarizationDate] DATE NOT NULL,
[VerifierID] INT NOT NULL,
PRIMARY KEY CLUSTERED ([InventarizationID] ASC),
FOREIGN KEY ([VerifierID]) REFERENCES [dbo].[Verifier] ([VerifierID])
ON DELETE CASCADE ON UPDATE CASCADE
);