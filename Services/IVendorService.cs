using APBD_TEST_TEMPLATE.DTOs;

namespace APBD_TEST_TEMPLATE.Services;

public interface IVendorService
{
    public Task<List<VendorResponseDto?>> GetVendorsAsync(string? name);
    public Task CreateVendorsAsync(CreateVendorsRequest createVendorsRequest);
    
}