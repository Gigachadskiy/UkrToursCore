using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class ExcursionsState
    {
        public ExcursionsState()
        {
            Excursions = new HashSet<Excursion>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Excursion> Excursions { get; set; }
    }
}
