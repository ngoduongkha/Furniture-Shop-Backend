#nullable disable

namespace Furniture_Shop_Backend.Models {
    public partial class InvoiceDetail {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Product Product { get; set; }
    }
}
