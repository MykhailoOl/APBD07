namespace WebApplication1.Properties.Repositories;

public interface IWarehouseRepository
{
    Task<bool> DoesProductExist(int IdProduct);
    Task<bool> DoesWarehouseExist(int IdWarehouse);
    Task<int?> DoesOrderExist(int IdProduct, int Amount, DateTime CreatedAt);
    Task<bool> DoesOrderCompleted(int? IdOrder);
    public void UpdateFullfilledAt(int? IdOrder, DateTime CreatedAt);
    public void AddProduct(int IdProduct, int IdWarehouse, int Amount, DateTime CreatedAt,int? IdOrder);
}