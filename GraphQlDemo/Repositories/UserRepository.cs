using GraphQlDemo.DTOs;
using GraphQlDemo.Models;
using GraphQlDemo.Persistance;

namespace GraphQlDemo.Repositories
{
    public class UserRepository
    {
        private readonly DemoGhCbContext _context;

        public UserRepository(DemoGhCbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers() => _context.Users;

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public User AddUser(UserDTO userDTO)
        {
            var user = new User()
            {
                Name = userDTO.Name,
                Email = userDTO.Email
            };

            var result = _context.Users.Add(user).Entity;
            _context.SaveChanges();
            return result;
        }

        public User AlterUser(int id, UserDTO userDTO)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Not found!");
            }
            user.Name = userDTO.Name;
            user.Email = userDTO.Email;
            _context.SaveChanges();
            return user;
        }
    }
}
