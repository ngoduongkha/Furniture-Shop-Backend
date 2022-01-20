using System;
using System.Collections.Generic;

#nullable disable

namespace Furniture_Shop_Backend.Models
{
    public partial class Topic
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string Displayname { get; set; }
        public string Discription { get; set; }

        public virtual Category Category { get; set; }
    }
}
