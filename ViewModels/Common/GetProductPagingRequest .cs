namespace Furniture_Shop_Backend.ViewModels.Common
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public int? CategoryId { get; set; }
    }
}
