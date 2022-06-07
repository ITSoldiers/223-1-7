using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BookService
    {
        DataBase DataBase = new DataBase();

        public void AddUser(UserDTO user)
        {

        }

        public UserDTO GetUser(string login, string password)
        {
            return new UserDTO()
            {
                Login = login,
                Password = password
            };
        }

        public List<Book> GetAll()
        {
            return DataBase.books;
        }

        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();

            foreach (var book in DataBase.books)
            {
                if (!genres.Contains(book.Genre))
                    genres.Add(book.Genre);
            }

            return genres;
        }

        public List<string> GetTypes()
        {
            List<string> types = new List<string>();
            
            foreach (var book in DataBase.books)
            {
                if (!types.Contains(book.Type))
                    types.Add(book.Type);
            }

            return types;
        }

        public List<Book> GetBooks(string genre, string bookType)
        {
            return DataBase.books.FindAll(book => book.Type == bookType && book.Genre == genre);
        }

        public Book GetBookById(int id)
        {
            return DataBase.books.Find(book => book.BookId == id);
        }

        public void AddBook(Book book)
        {
            DataBase.books.Add(book);
        }

        public void DeleteBookById(int id)
        {

        }
    }
}
