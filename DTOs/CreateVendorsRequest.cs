using System.ComponentModel.DataAnnotations;

namespace APBD_TEST_TEMPLATE.DTOs;

public class CreateVendorsRequest
{
    [Required]
    [MaxLength(10)]
    public string code { get; set; }
    [Required]
    [MaxLength(100)]
    public string name { get; set; }
    public List<CreateProducts> products { get; set; }
}