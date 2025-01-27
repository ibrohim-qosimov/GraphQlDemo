using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Persistance;

namespace GraphQlDemo.Repositories
{
    public class ProductRepository
    {
        private readonly DemoGhCbContext _context;

        public ProductRepository(DemoGhCbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts() => _context.Products;

        public Product GetProductById(int id) => _context.Products.FirstOrDefault(p => p.Id == id);

        public Product AddProduct(ProductDTO productDTO)
        {
            var product = new Product()
            {
                Name = productDTO.Name,
                Description = productDTO.Description
            };

            var result = _context.Products.Add(product).Entity;
            _context.SaveChanges();
            return result;
        }

        public Product AlterProduct(int id, ProductDTO productDTO)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new Exception("Not found!");
            }
            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            _context.SaveChanges();
            return product;
        }
    }
}
