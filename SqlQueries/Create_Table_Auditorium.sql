CREATE TABLE [dbo].[Auditorium] (
[AuditoriumID] CHAR (10) NOT NULL,
[ResponsibleID] INT NOT NULL,
[AuditoryType] TEXT NOT NULL,
PRIMARY KEY CLUSTERED ([AuditoriumID] ASC),
FOREIGN KEY ([ResponsibleID]) REFERENCES [dbo].[Responsible] ([ResponsibleID])
ON DELETE CASCADE ON UPDATE CASCADE
);