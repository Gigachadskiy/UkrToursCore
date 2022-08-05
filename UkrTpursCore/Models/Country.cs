using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
