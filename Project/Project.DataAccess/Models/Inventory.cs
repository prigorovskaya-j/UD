using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            Repairs = new HashSet<Repair>();
        }

        public int InventoryId { get; set; }
        public string AuditoriumId { get; set; }
        public int DocumentId { get; set; }
        public string CurrentState { get; set; }
        public byte Availability { get; set; }

        public virtual Auditorium Auditorium { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
