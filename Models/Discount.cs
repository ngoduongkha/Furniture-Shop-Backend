using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models {
    public partial class Discount {
        public Discount() {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public int? Percentage { get; set; }
        public string Description { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public decimal? MaxValue { get; set; }
        public decimal? MinPurchase { get; set; }
        public bool? IsMoney { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
