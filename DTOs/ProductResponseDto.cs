namespace APBD_TEST_TEMPLATE.DTOs;

public class ProductResponseDto
{
    public int id { get; set; }
    public string name { get; set; } = null!;
    public string description { get; set; } = null!;
    public decimal stickerPrice { get; set; }
    public ProductTypeDto productType { get; set; } = null!;
    public MakerDto maker { get; set; } = null!;
    public VendorOfferDto vendorOffer { get; set; } = null!;
}