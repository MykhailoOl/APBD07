namespace WebApplication1.Properties.Repositories;

public interface IWarehouseRepository
{
    Task<bool> DoesProductExist(int IdProduct);
    Task<bool> DoesWarehouseExist(int IdWarehouse);
    Task<bool> DoesOrderExist(int IdProduct,int Amount,DateTime CreatedAt);
}