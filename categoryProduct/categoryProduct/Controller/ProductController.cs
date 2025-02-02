using categoryProduct.Entities;
using categoryProduct.Repository;
using categoryProduct.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace categoryProduct.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetAllData")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await productService.GetAllProducts();
                return Ok(new { Success = true, Data = products });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "error" });
            }
        }

        [HttpPost("Insert data")]
        public async Task<IActionResult> AddProducts([FromBody] Products products)
        {
            if (products == null)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });

            }
            try
            {
                bool result = await productService.AddProduct(products);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { pro_id = products.pro_id }, new { Success = true, Message = "product created successfully" });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "not inserted" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "an error occurred while creating the product " });
            }
        }

        [HttpDelete("{pro_id}")]
        public async Task<IActionResult> DeleteProduct(int pro_id)
        {
            try
            {
                bool result = await productService.DeleteProduct(pro_id);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "product not found" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }

        }

        [HttpPut("{pro_id}")]
        public async Task<IActionResult> UpdateProduct(int pro_id, [FromBody] Products products)
        {
            if (products == null || pro_id != products.pro_id)
            {
                return BadRequest(new { Success = false, Message = "invalid details" });
            }
            try
            {
                bool result = await productService.UpdateProduct(products);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "product not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "internal server error" });
            }
        }

        [HttpGet("GetById/{pro_id}")]
        public async Task<IActionResult> GetById(int pro_id)
        {
            try
            {
                var result = await productService.GetByProId(pro_id);
                if (result != null)
                {
                    return Ok(new {Success=true,Data=result});      
                }
                else
                {
                    return NotFound(new { Success = false, Message = "product with this not found" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "internal server error" });
            }
        }

    }  
}

