using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Properties.Models;

public class ProductDTO
{
    [Required]
    public int IdProduct { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}