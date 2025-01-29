using GraphQlDemo.Models;
using GraphQlDemo.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphQlDemo.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProductQuery
    {

        /*
            
            GraphQL da ikkita asosiy type bor,Query va Muatation, Query 
            o'zimizdagi Get yani o'qish uchun ma'lumotni o'zgartirolmaydi faqat qaytaradi

         */

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
