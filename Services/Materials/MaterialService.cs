using Furniture_Shop_Backend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public class MaterialService : IMaterialService {
        public Task<int> CountExists(Material material) {
            throw new System.NotImplementedException();
        }

        public Task<Material> DeleteMaterial(Material material) {
            throw new System.NotImplementedException();
        }

        public Task<Material> DeleteMaterial(int materialId) {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetCategories() {
            throw new System.NotImplementedException();
        }

        public Task<Material> GetMaterial(int materialId) {
            throw new System.NotImplementedException();
        }

        public Task<bool> MaterialExists(Material material) {
            throw new System.NotImplementedException();
        }

        public Task<Material> PostMaterial(Material material) {
            throw new System.NotImplementedException();
        }

        public Task<Material> PutMaterial(Material material) {
            throw new System.NotImplementedException();
        }
    }
}
