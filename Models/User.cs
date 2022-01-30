using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models {
    public partial class User {
        public User() {
            Invoices = new HashSet<Invoice>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] CreateAt { get; set; }
        public string Image { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
