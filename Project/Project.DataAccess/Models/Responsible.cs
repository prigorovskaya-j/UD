using System;
using System.Collections.Generic;

#nullable disable

namespace Project.DataAccess.Models
{
    public partial class Responsible
    {
        public Responsible()
        {
            Auditoria = new HashSet<Auditorium>();
        }

        public int ResponsibleId { get; set; }
        public string ResponsibleName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Auditorium> Auditoria { get; set; }
    }
}
