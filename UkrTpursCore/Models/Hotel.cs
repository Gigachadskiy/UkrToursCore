using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int CityId { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }

        public virtual City City { get; set; } = null!;
    }
}
