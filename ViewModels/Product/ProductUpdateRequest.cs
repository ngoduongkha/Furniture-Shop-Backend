namespace Furniture_Shop_Backend.ViewModels.Product {
    public class ProductUpdateRequest {
        public int? CategoryId { set; get; }
        public int? BrandId { get; set; }
        public int? MaterialId { get; set; }
        public string Name { set; get; }
        public string Size { set; get; }
        public decimal? Price { set; get; }
        public int? Quantity { set; get; }
        public string Description { set; get; }
    }
}
