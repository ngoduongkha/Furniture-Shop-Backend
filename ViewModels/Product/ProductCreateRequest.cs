namespace Furniture_Shop_Backend.ViewModels.Product {
    public class ProductCreateRequest {
        public string ProductBasetId { get; set; }
        public int CategoryId { set; get; }
        public int BrandId { get; set; }
        public int MaterialId { get; set; }
        public string Size { set; get; }
        public decimal Price { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }

    }
}
