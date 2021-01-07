using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class List
    {
        public int ListId { get; set; }
        public string AuditoriumId { get; set; }
        public int InventarizationId { get; set; }

        public virtual Auditorium Auditorium { get; set; }
        public virtual Inventarization Inventarization { get; set; }
    }
}
