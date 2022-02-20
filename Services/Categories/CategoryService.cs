using Furniture_Shop_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public class CategoryService : ICategoryService {
        private readonly FurnitureShopContext _context;

        public CategoryService(FurnitureShopContext context) {
            _context = context;
        }

        public async Task<bool> CategoryExists(Category category) {
            return await _context.Categories.AnyAsync(e => e.Name == category.Name && e.IsDeleted == false);
        }

        public async Task<Category> DeleteCategory(Category category) {
            var result = await _context.Categories
                .FirstOrDefaultAsync(e => e == category);

            if (result != null) {
                _context.Categories.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<Category> DeleteCategory(int categoryId) {
            var result = await _context.Categories
                .FirstOrDefaultAsync(e => e.Id == categoryId);

            if (result != null) {
                _context.Categories.Remove(result);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories() {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategory(int categoryId) {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task<Category> PostCategory(Category category) {
            var result = await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> PutCategory(Category category) {
            var result = _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
