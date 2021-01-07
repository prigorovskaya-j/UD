using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Repair
    {
        public int RepairId { get; set; }
        public int InventoryId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Description { get; set; }

        public virtual Inventory Inventory { get; set; }
    }
}
