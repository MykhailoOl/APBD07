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
    public async Task<int?> DoesOrderExist(int IdWarehouse, int Amount, DateTime CreatedAt)
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
        
        if (res != null && res != DBNull.Value)
        {
            return Convert.ToInt32(res);
        }
        else
        {
            return null;
        }
    }
    public async Task<bool> DoesOrderCompleted(int? IdOrder)
    {
        if (IdOrder == null)
            return false;
        var query = "SELECT 1 FROM Product_WarehouseDTO WHERE OrderID = @ID";
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", IdOrder);

        await connection.OpenAsync();

        var res = await command.ExecuteScalarAsync();
        
        return res is null;
    }

    public void UpdateFullfilledAt(int? IdOrder, DateTime CreatedAt)
    {
        if (IdOrder != null)
        {
            var query = "UPDATE OrderDTO SET FulfilledAt = @CreatedAt WHERE IdOrder = @IdOrder";

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@OrderId", IdOrder);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);

            connection.OpenAsync();
        }
    }

    public void AddProduct(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt,int? IdOrder)
    {
        if (IdOrder != null)
        {
            var query = "INSERT INTO Product_WarehouseDTO (IdProductWarehouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt)VALUES (((SELECT ISNULL(Max(IdProductWarehouse),0) FROM Product_Warehouse) + 1), @IdWarehouse, @IdProduct,@IdOrder,@Amount, ((SELECT Price FROM Product WHERE IdProduct = @IdProduct) * @Amount), @CreatedAt";;

            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            using SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = query;
            command.Parameters.AddWithValue("@IdProduct", IdProduct);
            command.Parameters.AddWithValue("@IdWarehouse", IdWarehouse);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@CreatedAt", CreatedAt);
            command.Parameters.AddWithValue("@IdOrder", IdOrder);
            

            connection.OpenAsync();
        }
    }
}