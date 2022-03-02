using Furniture_Shop_Backend.ViewModels.Common;

namespace Furniture_Shop_Backend.ViewModels.Order
{
    public class GetOrderPagingRequest : PagingRequestBase 
    {
        public string SortBy { get; set; }
    }
}
