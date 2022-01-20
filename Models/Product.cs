﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Product
    {
        public Product()
        {
            ImportDetails = new HashSet<ImportDetail>();
            InvoiceDetails = new HashSet<InvoiceDetail>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public string Discription { get; set; }
        public int? Quantity { get; set; }
        public int? Cost { get; set; }
        public string Image { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ImportDetail> ImportDetails { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}