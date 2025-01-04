using GraphQlDemo.Models;
using GraphQlDemo.Repositories;

namespace GraphQlDemo.Queries
{
    public class ProductQuery
    {
        private readonly ProductRepository _repository;

        public ProductQuery(ProductRepository repository)
        {
            _repository = repository;
        }

        [GraphQLName("getProducts")]
        public IEnumerable<Product> GetProducts() => _repository.GetAllProducts();


        [GraphQLName("getProductById")]
        public Product GetProduct(int id) => _repository.GetProductById(id);
    }
}
