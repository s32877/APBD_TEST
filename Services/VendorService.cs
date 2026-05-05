using APBD_TEST_TEMPLATE.DTOs;
using APBD_TEST_TEMPLATE.Repositories;

namespace APBD_TEST_TEMPLATE.Services;

public class VendorService : IVendorService
{
    private readonly IVendorRepository _vendorRepository;

    public VendorService(IVendorRepository vendorRepository)
    {
        _vendorRepository = vendorRepository;
    }

    public Task<List<VendorResponseDto?>> GetVendorsAsync(string? name)
    {
        return _vendorRepository.GetVendorsAsync(name);
    }

    public Task CreateVendorsAsync(CreateVendorsRequest createVendorsRequest)
    {
        return _vendorRepository.CreateVendorsAsync(createVendorsRequest);
    }

}