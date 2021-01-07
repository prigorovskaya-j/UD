CREATE TABLE [dbo].[Responsibles] (
[ResponsibleID] INT NOT NULL IDENTITY(1,1),
[ResponsibleName] CHAR (30) NOT NULL,
[Password] CHAR (10) NOT NULL,
PRIMARY KEY CLUSTERED ([ResponsibleID] ASC)
);