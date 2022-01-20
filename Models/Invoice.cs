using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public byte[] CreateAt { get; set; }
        public int? DiscountId { get; set; }
        public string PaymentStatus { get; set; }
        public string DeliveryStatus { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
