using System.Data;
using APBD_TEST_TEMPLATE.DTOs;
using Microsoft.Data.SqlClient;

namespace APBD_TEST_TEMPLATE.Repositories;

public class VendorRepository  : IVendorRepository
{
    private readonly string _connectionString;

    public VendorRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Missing 'Default' connection string.");
    }

    public async Task<List<VendorResponseDto?>> GetVendorsAsync(string? name)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        var vendorsByCode = new Dictionary<string, VendorResponseDto>();
        await using (var command = new SqlCommand(@"
                                    SELECT V.CODE, V.NAME, P.ID, P.NAME, P.DESCRIPTION, P.STICKERPRICE, PT.ID, PT.NAME,
                                    M.ID, M.NAME, VO.AMOUNT, VO.PRICEPERUNIT FROM Vendors V
                                    JOIN VENDORPRODUCTS VP ON V.CODE = VP.VENDORCODE
                                    JOIN PRODUCTS P ON  P.ID = VP.PRODUCTID
                                    JOIN MAKERS M ON M.ID = P.MakerId
                                    JOIN PRODUCTTYPES PT ON PT.ID = P.ProductTypeId
                                    WHERE V.NAME LIKE @name
                                                           ", connection))
        {
            command.Parameters.AddWithValue("@name", name);
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var vendorCode =  reader.GetString(0);
                if (!vendorsByCode.TryGetValue(vendorCode, out var vendor))
                {
                    vendor = new VendorResponseDto
                    {
                        code = vendorCode,
                        name = reader.GetString(1),
                        products = new List<ProductResponseDto>()
                    };
                    vendorsByCode.Add(vendorCode, vendor);
                }
                
            }
            
        }
        return vendorsByCode.Values.ToList()!;
    }

    public async Task CreateVendorsAsync(CreateVendorsRequest createVendorsRequest)
    {
        await using var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync();
        
        await using var command = new SqlCommand(
            "INSERT INTO Vendors (Code, Name) VALUES (@code, @name);", connection);
        command.Parameters.AddWithValue("@code", createVendorsRequest.code);
        command.Parameters.AddWithValue("@name", createVendorsRequest.name);
        
        await command.ExecuteNonQueryAsync();
    }
    
}