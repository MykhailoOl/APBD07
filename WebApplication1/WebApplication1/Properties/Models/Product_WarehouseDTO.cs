using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Properties.Models;

public class Product_WarehouseDTO
{
    [Required] 
    public int IdProductWarehouse { get; set; }
    [Required] 
    public int IdWarehouse { get; set; }
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdOrder { get; set; }
    [Range(1,long.MaxValue)]
    public int Amount { get; set; }
    [DataType(DataType.Currency)]
    [Range(0.01, 9999999999999999999999999.99)]
    public decimal Price { get; set; }
    public DateTime CreatedAT { get; set; }
}