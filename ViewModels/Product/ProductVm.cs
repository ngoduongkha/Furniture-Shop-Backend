using System;
using System.Collections.Generic;

namespace Furniture_Shop_Backend.ViewModels.Common {
    public class ProductVm {
        public int Id { set; get; }
        public string ProductBasetId { get; set; }
        public decimal? Price { set; get; }
        public decimal? OriginalPrice { set; get; }
        public string Size { get; set; }
        public int? Quantity { set; get; }
        public DateTime? DateCreated { set; get; }
        public string Name { set; get; }
        public string Categories { get; set; }
        public string Brand { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string Material { set; get; }
        public List<string> UrlImages { get; set; } = new List<string>();
    }
}
