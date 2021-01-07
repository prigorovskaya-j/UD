CREATE TABLE [dbo].[Repairs] (
[RepairID] INT NOT NULL IDENTITY(1,1),
[InventoryID] INT NOT NULL,
[DateStart] DATE NOT NULL,
[DateEnd] DATE NULL,
[Description] TEXT NULL,
PRIMARY KEY CLUSTERED ([RepairID] ASC),
FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventories] ([InventoryID]) ON
DELETE CASCADE ON UPDATE CASCADE
);