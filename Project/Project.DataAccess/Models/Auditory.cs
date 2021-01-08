using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Auditory
    {
        public Auditory()
        {
            Inventories = new HashSet<Inventory>();
            Lists = new HashSet<List>();
        }

        public int AuditoriumId { get; set; }
        public int ResponsibleId { get; set; }
        public string AuditoryType { get; set; }

        public virtual Responsible Responsible { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<List> Lists { get; set; }
        public override string ToString()
        {
            return $"Id: {AuditoriumId},  Responsible: {ResponsibleId}, Type: {AuditoryType}";
        }
    }
}
