using Furniture_Shop_Backend.Models;
using Furniture_Shop_Backend.Services;
using Furniture_Shop_Backend.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furniture_Shop_Backend.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase {
        private readonly IBrandService _context;

        public BrandsController(IBrandService context) {
            _context = context;
        }

        //GET: api/Brands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands() {
            try {
                return Ok(await _context.GetBrands());
            }
            catch (Exception) {
                return NotFound();
            }
        }

        //GET: api/Brands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id) {
            try {
                var result = await _context.GetBrand(id);

                if (result == null) {
                    return NotFound();
                }

                return result;
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Brands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Brand>> PutBrand([FromRoute] int id, BrandViewModel brand) {
            try {
                var brandToUpdate = await _context.GetBrand(id);

                if (brandToUpdate == null) {
                    return NotFound();
                }

                brandToUpdate.Name = brand.Name;
                brandToUpdate.Description = brand.Description;

                // *******************************************************
                // ******       Lam sao de check unique :)))        ******
                // *******************************************************

                return await _context.PutBrand(brandToUpdate);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //POST: api/Brands
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(BrandViewModel brand) {
            try {
                if (brand == null) {
                    return BadRequest();
                }

                if (BrandExists(brand)) {
                    return BadRequest("Da ton tai");
                }

                var createdBrand = await _context.PostBrand(
                    new Brand {
                        Name = brand.Name,
                        Description = brand.Description
                    });

                return CreatedAtAction(nameof(GetBrand), new { id = createdBrand.Id }, createdBrand);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Brands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brand>> DeleteBrand(int id) {
            try {
                var brandToDelete = await _context.GetBrand(id);

                if (brandToDelete == null) {
                    return NotFound();
                }

                return await _context.DeleteBrand(brandToDelete);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool BrandExists(BrandViewModel brand) {
            return _context.BrandExists(
                new Brand {
                    Name = brand.Name,
                    Description = brand.Description
                }).Result;
        }
    }
}
