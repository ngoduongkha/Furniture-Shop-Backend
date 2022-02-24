using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models {
    public partial class Material {
        public Material() {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
