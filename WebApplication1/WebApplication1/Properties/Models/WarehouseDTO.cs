using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Properties.Models;

public class WarehouseDTO
{
    [Required]
    public int IdWarehouse { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
}