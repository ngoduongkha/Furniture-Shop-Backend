using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.Services;
using Furniture_Shop_Backend.ViewModels.Common;
using Furniture_Shop_Backend.Services.ProductImages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Furniture_Shop_Backend.ViewModels.Product;
using System;

namespace Furniture_Shop_Backend.Controllers {
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly IProductService _productService;
        private readonly IProductImagesService _productImagesService;

        public ProductsController(IProductService context, IProductImagesService productImagesService)
        {
            _productService = context;
            _productImagesService = productImagesService;
        }

        // GET: api/Products
        [HttpGet("paging-by-category")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory([FromQuery] GetProductPagingRequest request)
        {
            var product = await _productService.GetAllByCategoryId(request);
            if (product.TotalRecords < 1) return NotFound();
            return Ok(product);
        }
        [HttpGet("paging-all")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductPagingRequest request)
        {
            var product = await _productService.GetAllPaging(request);
            if(product.TotalRecords < 1) return NotFound(); 
            return Ok(product);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVm>> GetProduct([FromRoute] int id) {
            if (id < 1) return NotFound();
            var product = await _productService.GetById(id);
            if (product is null) return NotFound();
            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] ProductUpdateRequest product) {
            if (!ModelState.IsValid) {
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
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateRequest product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var result = await _productService.Create(product);
            if (!result.IsSuccessed)
                return BadRequest(result.Message);
            return Ok();
        }
        [HttpPost("set-images")]
        public async Task<ActionResult> SetImages([FromBody] ImagesCreate request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productImagesService.setUrlImages(request.ProductBaseId, request.urlsImage);
            if (!result.IsSuccessed)
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
