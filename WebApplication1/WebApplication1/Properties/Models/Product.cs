using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Properties.Models;

public class Product
{
    [Required]
    public int IdProduct { get; set; }
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    [Range(1,Int64.MaxValue)]
    public int Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
}