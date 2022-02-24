using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public interface ICategoryService {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int categoryId);
        Task<Category> PostCategory(Category category);
        Task<Category> PutCategory(Category category);
        Task<Category> DeleteCategory(Category category);
        Task<Category> DeleteCategory(int categoryId);
        Task<bool> CategoryExists(Category category);
    }
}
