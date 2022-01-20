using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }
        public string Displayname { get; set; }
        public string Discription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
