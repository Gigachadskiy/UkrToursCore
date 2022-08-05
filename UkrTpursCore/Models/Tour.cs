using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class Tour
    {
        public Tour()
        {
            Excursions = new HashSet<Excursion>();
            ToursCities = new HashSet<ToursCity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public int ManagerId { get; set; }
        public int TourTypeId { get; set; }

        public virtual ToursType TourType { get; set; } = null!;
        public virtual ICollection<Excursion> Excursions { get; set; }
        public virtual ICollection<ToursCity> ToursCities { get; set; }
    }
}
