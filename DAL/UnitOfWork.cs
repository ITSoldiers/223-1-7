using DAL.Entities;

namespace DAL
{
    public sealed class UnitOfWork : IDisposable
    {
        private LibraryContext _context;
        private static UnitOfWork? _unitOfWork;

        private IRepository<Book> _books;
        private IRepository<User> _users;
        public static UnitOfWork Unit
        {
            get
            {
                if(_unitOfWork == null)
                    _unitOfWork = new UnitOfWork(new LibraryContext());
                return _unitOfWork;
            }
        }

        public IRepository<Book> Books
        {
            get
            {
                if (_books == null)
                    _books = new BookRepository(_context);
                return _books;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (_users == null)
                    _users = new UserRepository(_context);
                return _users;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private UnitOfWork(LibraryContext context)
        {
            _context = context;
        }
    }
}
