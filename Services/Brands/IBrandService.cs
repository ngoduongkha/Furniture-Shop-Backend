using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public interface IBrandService {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(int brandId);
        Task<Brand> PostBrand(Brand brand);
        Task<Brand> PutBrand(Brand brand);
        Task<Brand> DeleteBrand(Brand brand);
        Task<Brand> DeleteBrand(int brandId);
        Task<bool> BrandExists(Brand brand);
    }
}
