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
        public int AuditoriumId { get; set; }
        public int DocumentId { get; set; }
        public string CurrentState { get; set; }
        public byte Availability { get; set; }

        public virtual Auditory Auditorium { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<Repair> Repairs { get; set; }
        public override string ToString()
        {
            return $"Id: {InventoryId},  Auditorie id: {AuditoriumId}, Document id: {DocumentId}, Current state: {CurrentState}, Availability: {Availability}";
        }
    }
}
