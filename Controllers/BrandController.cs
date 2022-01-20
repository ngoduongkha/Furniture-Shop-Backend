using Furniture_Shop_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            using (var context = new FurnitureShopContext())
            {
                return context.Brands.ToList();
            }
        }
    }
}
