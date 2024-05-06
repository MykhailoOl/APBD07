namespace WebApplication1.Properties.Repositories;

public interface IWarehouseRepository
{
    Task<bool> DoesProductExist(int id);
}