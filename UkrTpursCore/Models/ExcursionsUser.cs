using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class ExcursionsUser
    {
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public int UserId { get; set; }

        public virtual Excursion Excursion { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
