using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Furniture_Shop_Backend.Services {
    public class ProductImagesService : IProductImagesService {
        private readonly FurnitureShopContext _context;
        public ProductImagesService(FurnitureShopContext context) {
            _context = context;
        }

        public Task<List<string>> GetUrlsByIdProductbase(string idProductbase) {
            throw new System.NotImplementedException();
        }
        /*  public Task<List<string>> GetUrlsByIdProductbase(string idProductbase)
 {
    var query = from p in _context.Products
                join im in _context.ProductImages on p.ProductBasetId equals im.ProductBaseId
 }*/
    }
}
