using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Repositories;

namespace GraphQlDemo.Mutations
{
    public class ProductMutation
    {
        public ProductRepository _repository;

        public ProductMutation(ProductRepository repository)
        {
            _repository = repository;
        }

        public Product AddProduct(string name, string description)
        {
            var productDTO = new ProductDTO { Name = name, Description = description };
            var result = _repository.AddProduct(productDTO);
            return result;
        }
    }
}
