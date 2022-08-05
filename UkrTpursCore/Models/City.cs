using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class City
    {
        public City()
        {
            Hotels = new HashSet<Hotel>();
            ToursCities = new HashSet<ToursCity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Hotel> Hotels { get; set; }
        public virtual ICollection<ToursCity> ToursCities { get; set; }
    }
}
