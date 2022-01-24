using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.ViewModels.Common;
using Furniture_Shop_Backend.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services.Products
{
    public interface IProductService
    {
        Task<ApiResult<bool>> Create(ProductCreateRequest request);

        Task<ApiResult<ProductVm>> Update(int id, ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductVm> GetById(int productId);

        Task<PagedResult<ProductVm>> GetAllPaging(GetProductPagingRequest request);

        Task<PagedResult<ProductVm>> GetAllByCategoryId( GetProductPagingRequest request);
    }
}
