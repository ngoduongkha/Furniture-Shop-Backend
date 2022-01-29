using Furniture_Shop_Backend.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services.ProductImages
{
    public interface IProductImagesService
    {
        Task<List<string>> GetUrlsByIdProductbase(string idProductbase);
        public Task<ApiResult<bool>> setUrlImages(string idProductbase, List<string> urlImages);
    }
}
