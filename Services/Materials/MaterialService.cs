using Furniture_Shop_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Services {
    public class MaterialService : IMaterialService {
        private readonly FurnitureShopContext _context;

        public MaterialService(FurnitureShopContext context) {
            _context = context;
        }

        public Task<Material> DeleteMaterial(Material material) {
            throw new System.NotImplementedException();
        }

        public Task<Material> DeleteMaterial(int materialId) {
            throw new System.NotImplementedException();
        }

        public async Task<Material> GetMaterial(int materialId) {
            return await _context.Materials.FindAsync(materialId);
        }

        public async Task<IEnumerable<Material>> GetMaterials() {
            return await _context.Materials.ToListAsync();
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
