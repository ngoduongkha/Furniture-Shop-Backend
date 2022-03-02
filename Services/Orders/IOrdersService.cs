using Furniture_Shop_Backend.ViewModels.Common;
using Furniture_Shop_Backend.ViewModels.Order;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services.Orders
{
    public interface IOrdersService
    {
        Task<ApiResult<bool>> Create(OrderCreateRequest request);

        Task<ApiResult<int>> Update(int id, int request);
        Task<ApiResult<bool>> UpdateStatusDelivery(int id, string status);
        Task<ApiResult<bool>> UpdateStatusPayment(int id, string status);
        Task<int> Delete(int productId);

        Task<OrderVm> GetById(int id);

        Task<PagedResult<OrderVm>> GetAllPaging(GetOrderPagingRequest request);
        Task<bool> CheckExist(string productName);
    }
}
