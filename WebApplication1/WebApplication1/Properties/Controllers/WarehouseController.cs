using Microsoft.AspNetCore.Mvc;
using WebApplication1.Properties.Models;
using WebApplication1.Properties.Repositories;

namespace WebApplication1.Properties.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private readonly WarehouseRepository _warehouseRepository;
    public WarehouseController (WarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(int IdProduct,int IdWarehouse,int Amount,DateTime CreatedAt)
    {
        if (!await _warehouseRepository.DoesProductExist(IdProduct))
            return NotFound();
        if (!await _warehouseRepository.DoesWarehouseExist(IdWarehouse))
            return NotFound();
        if (Amount < 0)
            return BadRequest("Amount cannot be negative");
        if (!await _warehouseRepository.DoesOrderExist(IdWarehouse,Amount,CreatedAt))
            return NotFound();
    }
}