using GraphQlDemo.Models;
using GraphQlDemo.Repositories;
namespace GraphQlDemo.Queries
{
    public class UserQuery
    {
        private readonly UserRepository _repository;

        public UserQuery(UserRepository repository)
        {
            _repository = repository;
        }

        [GraphQLName("getUsers")]
        public IEnumerable<User> GetUsers() => _repository.GetAllUsers();


        [GraphQLName("getUserById")]
        public User GetUser(int id) => _repository.GetUserById(id);
    }
}
