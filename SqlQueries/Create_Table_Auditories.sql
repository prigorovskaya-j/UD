CREATE TABLE [dbo].[Auditories] (
[AuditoriumID] INT NOT NULL IDENTITY(1,1),
[ResponsibleID] INT NOT NULL,
[AuditoryType] TEXT NOT NULL,
PRIMARY KEY CLUSTERED ([AuditoriumID] ASC),
FOREIGN KEY ([ResponsibleID]) REFERENCES [dbo].[Responsibles] ([ResponsibleID])
ON DELETE CASCADE ON UPDATE CASCADE
);