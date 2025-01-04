using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Repositories;

namespace GraphQlDemo.Mutations
{
    public class ProductMutation
    {

        /*
         
            ## Mutation lar serverda o'zgartirish kiritish uchun ishlatiladi(yaratish,o'chirish hamda, o'zgartirish) va graphql dagi asosiy so'rov turi hisoblanadi.
         
         */
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
