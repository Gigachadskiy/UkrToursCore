using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class ToursCity
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int CityId { get; set; }
        public int CityOrder { get; set; }
        public int? HotelId { get; set; }
        public int? Days { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
    }
}
