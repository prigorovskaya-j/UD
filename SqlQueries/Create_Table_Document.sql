CREATE TABLE [dbo].[Document] (
[Document_number] INT NOT NULL,
[Inventory_name] CHAR (10) NOT NULL,
[Duration_of_use] INT NOT NULL,
[Start_date] DATE NOT NULL,
[End_data] DATE NULL,
[Reason] TEXT NULL,
PRIMARY KEY CLUSTERED ([Document_number] ASC)
);