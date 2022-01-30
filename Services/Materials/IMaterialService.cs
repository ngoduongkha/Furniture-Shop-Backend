using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public interface IMaterialService {
        Task<IEnumerable<Material>> GetCategories();
        Task<Material> GetMaterial(int materialId);
        Task<Material> PostMaterial(Material material);
        Task<Material> PutMaterial(Material material);
        Task<Material> DeleteMaterial(Material material);
        Task<Material> DeleteMaterial(int materialId);
        Task<bool> MaterialExists(Material material);
        Task<int> CountExists(Material material);
    }
}
