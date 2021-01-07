CREATE TABLE [dbo].[Inventarization] (
[Check_number] INT NOT NULL,
[Date] DATE NOT NULL,
[Checker_id] INT NOT NULL,
PRIMARY KEY CLUSTERED ([Check_number] ASC),
FOREIGN KEY ([Checker_id]) REFERENCES [dbo].[Check] ([Checker_id])
ON DELETE CASCADE ON UPDATE CASCADE
);