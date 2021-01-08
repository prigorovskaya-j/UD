using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Document
    {
        public Document()
        {
            Inventories = new HashSet<Inventory>();
        }

        public int DocumentId { get; set; }
        public string InventoryName { get; set; }
        public int DurationOfUse { get; set; }
        public DateTime DateUsedFrom { get; set; }
        public DateTime? DateUsedTo { get; set; }
        public string Reason { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public override string ToString()
        {
            return $"Id: {DocumentId}, Name: {InventoryName}, Used From: {DateUsedFrom}, Reason: {Reason}";
        }
    }
}
