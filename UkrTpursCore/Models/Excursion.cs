using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class Excursion
    {
        public Excursion()
        {
            ExcursionsUsers = new HashSet<ExcursionsUser>();
        }

        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public int ManagerId { get; set; }
        public int? GuideFirstId { get; set; }
        public int? GuideSecondId { get; set; }
        public int? TransportId { get; set; }
        public int StateId { get; set; }
        public int? AlbumId { get; set; }

        public virtual Album? Album { get; set; }
        public virtual ExcursionsState State { get; set; } = null!;
        public virtual Tour Tour { get; set; } = null!;
        public virtual ICollection<ExcursionsUser> ExcursionsUsers { get; set; }
    }
}
