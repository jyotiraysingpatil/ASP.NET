using categoryProduct.Entities;
using categoryProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace categoryProduct.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await _categoryService.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "error" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Categories categories)
        {
            if (categories == null)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });
            }
            try
            {
                bool result = await _categoryService.AddCategory(categories);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { cat_id = categories.cat_id }, new { Success = true, Message = "category created successfully" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "not inserted" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "an error occurred while creating the category" });

            }
        }

        [HttpPut("{cat_id}")]
        public async Task<IActionResult> UpdateCategory(int cat_id, [FromBody] Categories categories)
        {
            if (categories == null || cat_id != categories.cat_id)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });
            }
            try
            {
                bool result = await _categoryService.UpdateCategory(categories);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "category not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "internal server error" });
            }
        }

        [HttpDelete("{cat_id}")]
        public async Task<IActionResult> DeleteCategory(int cat_id)
        {
            try
            {
                bool result = await _categoryService.DeleteCategory(cat_id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "category not found" });
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "internal server error" });
            }
        }
    }
}
