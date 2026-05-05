namespace APBD_TEST_TEMPLATE.DTOs;

public class VendorResponseDto
{
    public string code { get; set; } = null!;
    public string name { get; set; } = null!;
    public List<ProductResponseDto> products { get; set; } = null!;
}