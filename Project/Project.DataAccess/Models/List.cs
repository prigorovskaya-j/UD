using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class List
    {
        public int ListId { get; set; }
        public int AuditoriumId { get; set; }
        public int InventarizationId { get; set; }

        public virtual Auditory Auditorium { get; set; }
        public virtual Inventarization Inventarization { get; set; }
        public override string ToString()
        {
            return $"Id: {ListId},  Auditorie id: {AuditoriumId}, Inventarization id: {InventarizationId}";
        }
    }
}
