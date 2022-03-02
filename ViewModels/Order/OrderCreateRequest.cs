namespace Furniture_Shop_Backend.ViewModels.Order
{
    public class OrderCreateRequest
    {
        public int UserId { set; get; }
        public int VoucherId { set; get; }
        public string Destination { set; get; }
        public OrderItem[] orderItems { set; get; }

    }
}
