using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GraphQlDemo.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProductMutation
    {

        /*
         
            ## Mutation lar serverda o'zgartirish kiritish uchun ishlatiladi(yaratish,o'chirish hamda, o'zgartirish) va graphql dagi asosiy so'rov turi hisoblanadi.
         
         */
        private readonly ProductRepository _repository;

        public ProductMutation(ProductRepository repository)
        {
            _repository = repository;
        }

        [GraphQLName("addProduct")]
        public Product AddProduct(string name, string description)
        {
            var productDTO = new ProductDTO { Name = name, Description = description };
            var result = _repository.AddProduct(productDTO);
            return result;
        }

        [GraphQLName("alterProduct")]
        public Product AlterProduct(int id, string name, string description)
        {
            var productDTO = new ProductDTO { Name = name, Description = description };
            var result = _repository.AlterProduct(id, productDTO);
            return result;
        }
    }
}
