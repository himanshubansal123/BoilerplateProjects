using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductRepository _productsRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productsRepository = productRepository;
        }
        
        [HttpGet]
        public ActionResult GetProducts()
        {
            List<Product> products = _productsRepository.GetAllProducts();
            return Ok(products);
        }

        [Route("addProduct")]
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            bool status = _productsRepository.AddProduct(product);
            return Created("api/Created", status);
        }
        [Route("getProductById/{id:int}")]
        [HttpGet]
        public ActionResult GetProudctById(int id)
        {
            Product product = _productsRepository.GetProductById(id);   
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound($"Product with id : {id} not found");
            }
        }



    }
}
