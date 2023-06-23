using WebApplication2.Models;

namespace WebApplication2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ILogger Logger { get; set; }
        List<Product> products;
        public ProductRepository(ILogger<ProductRepository> logger)
        {
            Logger = logger;
            products = new List<Product>()
            {
                new Product(){ Id = 1, Name = "Himanshu",Price =200},
                 new Product(){ Id = 2, Name = "Atharva", Price = 100 },
                  new Product() { Id = 3, Name = "Prashik", Price = 300 },
            };
        }

        public bool AddProduct(Product product)
        {
            products.Add(product);  
            return true;
        }

        public List<Product> GetAllProducts() {
            Logger.LogInformation("Getting  entity to the repository:");
            return products;
        }

        public Product GetProductById(int id) { 
        Product prod = products.Find(x => x.Id == id);
            return prod;
        }

    }
}
