namespace Furniture_Shop_Backend.ViewModels.Order
{
    public class OrderVm
    {
        public int Id { get; set; }
        public int UserId { set; get; }
        public string UserName { set; get; }
        public int VoucherId { set; get; }
        public string VoucherDesc { set; get; }
        public string CreateDate { set; get; }
        public string DeliveryStatus { set; get; }
        public string PaymentStatus { set; get; }
        public string Destination { set; get; }
        public OrderItemVm[] orderItems { set; get; }

    }
}
