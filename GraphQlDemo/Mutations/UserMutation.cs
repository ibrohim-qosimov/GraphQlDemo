using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Repositories;

namespace GraphQlDemo.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class UserMutation
    {
        private readonly UserRepository _repository;

        public UserMutation(UserRepository repository)
        {
            _repository = repository;
        }

        [GraphQLName("addUser")]
        public User AddUser(string name, string email)
        {
            var userDTO = new UserDTO { Name = name, Email = email };
            var result = _repository.AddUser(userDTO);
            return result;
        }

        [GraphQLName("alterUser")]
        public User AlterUser(int id, string name, string email)
        {
            var userDTO = new UserDTO { Name = name, Email = email };
            var result = _repository.AlterUser(id, userDTO);
            return result;
        }
    }
}
