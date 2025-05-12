using Microsoft.AspNetCore.Mvc;
using tutorial8.Services.Abstractions;
using tutorial8.Entities;

namespace tutorial8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
        {
            var warehouses = await _warehouseService.GetAllWarehousesAsync();
            return Ok(warehouses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
        {
            var warehouse = await _warehouseService.GetWarehouseByIdAsync(id);

            if (warehouse == null)
            {
                return NotFound();
            }

            return Ok(warehouse);
        }

        [HttpPost]
        public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
        {
            await _warehouseService.AddWarehouseAsync(warehouse);
            return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.Id }, warehouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarehouse(int id, Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return BadRequest();
            }

            await _warehouseService.UpdateWarehouseAsync(warehouse);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            await _warehouseService.DeleteWarehouseAsync(id);
            return NoContent();
        }
    }
}
