using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class ToursType
    {
        public ToursType()
        {
            Tours = new HashSet<Tour>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
