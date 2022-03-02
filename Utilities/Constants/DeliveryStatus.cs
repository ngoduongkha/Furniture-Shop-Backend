namespace Furniture_Shop_Backend.Utilities.Constants
{
    public class DeliveryStatus
    {
        public const string Pending = "PENDING";
        public const string Processing = "PROCESSING";
        public const string Delivery = "DELIVERY";
        public const string Complete = "COMPLETE";
        public const string Cancle = "CANCLE";

        public const string PendingVN = "Đơn mới tiếp nhận";
        public const string ProcessingVN = "Đang lên đơn";
        public const string DeliveryVN = "Đã giao cho bên vận chuyển";
        public const string CompleteVN = "Thành công";
        public const string CancleVN = "Bị hủy";
    }
}
