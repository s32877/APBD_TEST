using APBD_TEST_TEMPLATE.Repositories;
using APBD_TEST_TEMPLATE.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_TEST_TEMPLATE.Controllers;

[ApiController]
[Route("api/vendors")]
public class VendorsController : ControllerBase
{
    private readonly IVendorService _vendorService;

    public VendorsController(IVendorService vendorService)
    {
        _vendorService = vendorService;
    }
    [HttpGet]
    public async Task<IActionResult> GetVendors([FromQuery] string? name)
    {
        var vendor = await _vendorService.GetVendorsAsync(name);
        return Ok(vendor);
    }
}