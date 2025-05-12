using Microsoft.AspNetCore.Mvc;
using tutorial8.Services.Abstractions;
using tutorial8.Entities;

namespace tutorial8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductWarehouseController : ControllerBase
    {
        private readonly IProductWarehouseService _productWarehouseService;

        public ProductWarehouseController(IProductWarehouseService productWarehouseService)
        {
            _productWarehouseService = productWarehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductWarehouse>>> GetProductWarehouses()
        {
            var productWarehouses = await _productWarehouseService.GetAllProductWarehousesAsync();
            return Ok(productWarehouses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductWarehouse>> GetProductWarehouse(int id)
        {
            var productWarehouse = await _productWarehouseService.GetProductWarehouseByIdAsync(id);

            if (productWarehouse == null)
            {
                return NotFound();
            }

            return Ok(productWarehouse);
        }

        [HttpPost]
        public async Task<ActionResult<ProductWarehouse>> PostProductWarehouse(ProductWarehouse productWarehouse)
        {
            await _productWarehouseService.AddProductWarehouseAsync(productWarehouse);
            return CreatedAtAction(nameof(GetProductWarehouse), new { id = productWarehouse.Id }, productWarehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductWarehouse(int id, ProductWarehouse productWarehouse)
        {
            if (id != productWarehouse.Id)
            {
                return BadRequest();
            }

            await _productWarehouseService.UpdateProductWarehouseAsync(productWarehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductWarehouse(int id)
        {
            await _productWarehouseService.DeleteProductWarehouseAsync(id);
            return NoContent();
        }
    }
}
