CREATE TABLE [dbo].[Inventory] (
[Inventory_number] INT NOT NULL,
[Auditorium_number] CHAR (10) NOT NULL,
[Document_number] INT NOT NULL,
[State] CHAR (10) NOT NULL,
[Availability] TINYINT NOT NULL,
PRIMARY KEY CLUSTERED ([Inventory_number] ASC),
FOREIGN KEY ([Auditorium_number]) REFERENCES [dbo].[Auditorium] ([Auditorium_number]) ON
DELETE CASCADE ON UPDATE CASCADE,
FOREIGN KEY ([Document_number]) REFERENCES [dbo].[Document] ([Document_number]) ON
DELETE CASCADE ON UPDATE CASCADE
);