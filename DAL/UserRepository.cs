using DAL.Entities;

namespace DAL
{
    public class UserRepository : IRepository<User>
    {
        private readonly LibraryContext _context;
        public UserRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public void Remove(int id)
        {
            var user = _context.Users.Find(id);
            if(user != null)
                _context.Users.Remove(user);
        }
    }
}
