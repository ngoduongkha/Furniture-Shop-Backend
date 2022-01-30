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
    public class CategoriesController : ControllerBase {
        private readonly ICategoryService _context;

        public CategoriesController(ICategoryService context) {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories() {
            try {
                return Ok(await _context.GetCategories());
            }
            catch (Exception) {
                return NotFound();
            }
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id) {
            try {
                var result = await _context.GetCategory(id);

                if (result == null) {
                    return NotFound();
                }

                return result;
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category) {
            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryViewModel category) {
            try {
                if (category == null) {
                    return BadRequest();
                }

                if (CategoryExists(category)) {
                    return BadRequest("Da ton tai");
                }

                var createdCategory = await _context.PostCategory(
                    new Category {
                        Name = category.Name,
                        Description = category.Description
                    });

                return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id) {
            try {
                var categoryToDelete = await _context.GetCategory(id);

                if (categoryToDelete == null) {
                    return NotFound();
                }

                return await _context.DeleteCategory(categoryToDelete);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private bool CategoryExists(CategoryViewModel category) {
            return _context.CategoryExists(
                new Category {
                    Name = category.Name,
                    Description = category.Description
                }).Result;
        }

        private int CountExists(CategoryViewModel category) {
            return _context.CountExists(
                new Category {
                    Name = category.Name,
                    Description = category.Description
                }).Result;
        }
    }
}
