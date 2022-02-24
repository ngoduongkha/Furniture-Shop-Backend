using Furniture_Shop_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public class BrandService : IBrandService {
        private readonly FurnitureShopContext _context;

        public BrandService(FurnitureShopContext context) {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrands() {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrand(int brandId) {
            return await _context.Brands.FindAsync(brandId);
        }

        public async Task<Brand> PostBrand(Brand brand) {
            var result = await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Brand> PutBrand(Brand brand) {
            var result = _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Brand> DeleteBrand(Brand brand) {
            var result = await _context.Brands
                .FirstOrDefaultAsync(e => e == brand);

            if (result != null) {
                _context.Brands.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Brand> DeleteBrand(int brandId) {
            var result = await _context.Brands
                .FirstOrDefaultAsync(e => e.Id == brandId);

            if (result != null) {
                _context.Brands.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<bool> BrandExists(Brand brand) {
            return await _context.Brands
                .AnyAsync(e => e.Name == brand.Name && e.IsDeleted == false);
        }
    }
}
