using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Remove(int id)
        {
            var book = _context.Books.Find(id);
            if(book != null)
                _context.Books.Remove(book);
        }
    }
}
