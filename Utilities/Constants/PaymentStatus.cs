namespace Furniture_Shop_Backend.Utilities.Constants
{
    public class PaymentStatus
    {
        public const string UnPaid = "UNPAID";
        public const string Failed = "FAILED";
        public const string Refund = "REFUND";
        public const string Paid = "PAID";
        public const string PartiallyPaid = "PARTIALLY_PAID";

        public const string UnPaidVN = "Chưa thanh toán";
        public const string FailedVN = "Đơn hủy";
        public const string RefundVN = "Hoàn tiền";
        public const string PaidVN = "Đã thanh toán";
        public const string PartiallyPaidVN = "Thanh toán một phần";
    }
}
