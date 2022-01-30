using System;

#nullable disable

namespace Furniture_Shop_Backend.Models {
    public partial class Voucher {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public decimal? Value { get; set; }
        public decimal? MinPurchase { get; set; }
    }
}
