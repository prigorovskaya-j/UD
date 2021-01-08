using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Responsible
    {
        public Responsible()
        {
            Auditories = new HashSet<Auditory>();
        }

        public int ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Auditory> Auditories { get; set; }
        public override string ToString()
        {
            return $"Id: {ResponsibleId},  name: {ResponsibleName}, password: {Password}";
        }
    }
}
