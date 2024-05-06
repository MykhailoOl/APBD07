using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.JavaScript;

namespace WebApplication1.Properties.Models;

public class OrderDTO
{
    [Required] 
    public int IdOrder { get; set; }
    [Required]
    public int IdProduct { get; set; }
    [Range(1,long.MaxValue)]
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? FulfilledAt { get; set; }
}