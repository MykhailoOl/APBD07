using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;


namespace WebApplication1.Properties.Repositories;

public class WarehouseRepository : IWarehouseRepository
{
    private readonly IConfiguration _configuration;

    public WarehouseRepository (IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public async Task<bool> DoesProductExist(int IdProduct)
    {
        var query = "SELECT 1 FROM ProductDTO WHERE IdProduct = @ID";
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", IdProduct);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        
        return res is not null;
    }
    public async Task<bool> DoesWarehouseExist(int IdWarehouse)
    {
        var query = "SELECT 1 FROM WarehouseDTO WHERE IdWarehouse = @ID";
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", IdWarehouse);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        
        return res is not null;
    }
    public async Task<bool> DoesOrderExist(int IdWarehouse,int Amount,DateTime CreatedAt)
    {
        var query = "SELECT 1 FROM OrderDTO WHERE IdWarehouse = @ID AND Amount = @Amount AND CreatedAt > @CreatedAt";
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", IdWarehouse);
        command.Parameters.AddWithValue("@Amount", Amount);
        command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        
        return res is not null;
    }
}