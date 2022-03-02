namespace Furniture_Shop_Backend.ViewModels.Order
{
    public class OrderItemVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
