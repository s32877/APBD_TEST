using APBD_TEST_TEMPLATE.DTOs;

namespace APBD_TEST_TEMPLATE.Repositories;

public interface IVendorRepository
{
    public Task<List<VendorResponseDto?>> GetVendorsAsync(string? name);
    public Task CreateVendorsAsync(CreateVendorsRequest createVendorsRequest);
}