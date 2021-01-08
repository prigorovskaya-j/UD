using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Verifier
    {
        public Verifier()
        {
            Inventarizations = new HashSet<Inventarization>();
        }

        public int VerifierId { get; set; }
        public string VefifierName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Inventarization> Inventarizations { get; set; }
        public override string ToString()
        {
            return $"Id: {VerifierId},  Name: {VefifierName}, password: {Password}";
        }
    }
}
