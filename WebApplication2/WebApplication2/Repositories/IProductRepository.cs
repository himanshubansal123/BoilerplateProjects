using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public interface IProductRepository
    {
        ILogger Logger { get; set; }
        bool AddProduct(Product product);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
    }
}
