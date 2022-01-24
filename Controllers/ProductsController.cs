using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.Services.Products;
using Furniture_Shop_Backend.ViewModels.Product;
using Furniture_Shop_Backend.ViewModels.Common;

namespace Furniture_Shop_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService context)
        {
            _productService = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory()
        {
            // return await _context.Products.ToListAsync();
            return NoContent();
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductPagingRequest request)
        {
                // return await _context.Products.ToListAsync();
                return NoContent();
        }

            // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return NoContent();
            
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]int id,[FromBody] ProductUpdateRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Update(id, product);
            if (!result.IsSuccessed)
                return BadRequest(result.Message);
            return Ok(result.ResultObj);
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.Create(product);
            if(!result.IsSuccessed)
            return BadRequest(result.Message);
            return Ok();
        }
            // DELETE: api/Products/5
            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
                return NoContent();
        }

     
    }
}
