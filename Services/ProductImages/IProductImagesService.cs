using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public interface IProductImagesService {
        Task<List<string>> GetUrlsByIdProductbase(string idProductbase);
    }
}
