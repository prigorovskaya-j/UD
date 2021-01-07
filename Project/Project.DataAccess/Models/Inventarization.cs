using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Inventarization
    {
        public Inventarization()
        {
            Lists = new HashSet<List>();
        }

        public int InventarizationId { get; set; }
        public DateTime InventarizationDate { get; set; }
        public int VerifierId { get; set; }

        public virtual Verifier Verifier { get; set; }
        public virtual ICollection<List> Lists { get; set; }
    }
}
