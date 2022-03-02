using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? Score { get; set; }
        public string Description { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
