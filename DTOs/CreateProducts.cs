using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_TEMPLATE.DTOs;

public class CreateProducts
{
    [Required]
    public int id { get; set; }
    [Required]
    public int amount { get; set; }
    [Required]
    public decimal pricePerUnit { get; set; }
}