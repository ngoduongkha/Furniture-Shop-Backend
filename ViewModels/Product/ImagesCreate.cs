using System.Collections.Generic;

namespace Furniture_Shop_Backend.ViewModels.Product
{
    public class ImagesCreate
    {
        public string ProductBaseId { get; set; }
        public List<string> urlsImage { get; set; }
    }
}
