using System;
using System.Collections.Generic;

namespace UkrTpursCore.Models
{
    public partial class User
    {
        public User()
        {
            ExcursionsUsers = new HashSet<ExcursionsUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; } = null!;
        public string? Email { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<ExcursionsUser> ExcursionsUsers { get; set; }
    }
}
