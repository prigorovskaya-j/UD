CREATE TABLE [dbo].[Verifiers] (
[VerifierID] INT NOT NULL IDENTITY(1,1),
[VefifierName] CHAR (30) NOT NULL,
[Password] CHAR (10) NOT NULL,
PRIMARY KEY CLUSTERED ([VerifierID] ASC)
);