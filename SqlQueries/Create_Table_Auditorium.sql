CREATE TABLE [dbo].[Auditorium] (
[Auditorium_number] CHAR (10) NOT NULL,
[Responsible_id] INT NOT NULL,
[Auditory_type] TEXT NOT NULL,
PRIMARY KEY CLUSTERED ([Auditorium_number] ASC),
FOREIGN KEY ([Responsible_id]) REFERENCES [dbo].[Responsible] ([Responsible_id])
ON DELETE CASCADE ON UPDATE CASCADE
);