using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? ProductId { get; set; }
        public string ProductBasetId { get; set; }
        public int? Priority { get; set; }

        public virtual Product Product { get; set; }
    }
}
