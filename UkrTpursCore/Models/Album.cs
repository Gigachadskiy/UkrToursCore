using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class Album
    {
        public Album()
        {
            Excursions = new HashSet<Excursion>();
        }

        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<Excursion> Excursions { get; set; }
    }
}
