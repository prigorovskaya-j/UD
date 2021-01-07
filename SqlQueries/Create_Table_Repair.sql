CREATE TABLE [dbo].[Repair] (
[RepairID] INT NOT NULL,
[InventoryID] INT NOT NULL,
[DateStart] DATE NOT NULL,
[DateEnd] DATE NULL,
[Description] TEXT NULL,
PRIMARY KEY CLUSTERED ([RepairID] ASC),
FOREIGN KEY ([InventoryID]) REFERENCES [dbo].[Inventory] ([InventoryID]) ON
DELETE CASCADE ON UPDATE CASCADE
);