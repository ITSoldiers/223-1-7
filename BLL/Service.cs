using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;

namespace BLL
{
    public class Service
    {
        private readonly IMapper _mapper; 
        public Service()
        {
            _mapper = new MapperConfiguration
                (cfg => cfg.AddProfile<ServiceProfile>()).CreateMapper();
        }

        public void AddUser(UserDTO user)
        {
            UnitOfWork.Unit.Users.Add(_mapper.Map<User>(user));
            UnitOfWork.Unit.Save();
        }

        public UserDTO GetUser(string login, string password)
        {
            var user = UnitOfWork.Unit.Users.GetAll().FirstOrDefault(x => x.Login.Contains(login) && x.Password.Contains(password));
            return _mapper.Map<UserDTO>(user);
        }

        public List<BookDTO> GetAll()
        {
            var books = UnitOfWork.Unit.Books.GetAll();
            var dtos = new List<BookDTO>();
            foreach (var book in books)
                dtos.Add(_mapper.Map<BookDTO>(book));
            return dtos;
        }

        public List<string?> GetGenres()
        {
            return UnitOfWork.Unit.Books.GetAll().Select(x => x.Genre).Distinct().ToList();
        }

        public List<string?> GetTypes()
        {
            return UnitOfWork.Unit.Books.GetAll().Select(x => x.Type).Distinct().ToList();
        }

        public List<BookDTO> GetBooks(string genre, string bookType)
        {
            var books = UnitOfWork.Unit.Books.GetAll().Where(x => x.Genre.Contains(genre)).Where(x => x.Type.Contains(bookType));
            var dtos = new List<BookDTO>();
            foreach (var book in books)
                dtos.Add(_mapper.Map<BookDTO>(book));
            return dtos;
        }

        public BookDTO GetBookById(int id)
        {
            return _mapper.Map<BookDTO>(UnitOfWork.Unit.Books.GetById(id));
        }

        public void AddBook(BookDTO book)
        {
            UnitOfWork.Unit.Books.Add(_mapper.Map<Book>(book));
            UnitOfWork.Unit.Save();
        }

        public void DeleteBookById(int id)
        {
            UnitOfWork.Unit.Books.Remove(id);
            UnitOfWork.Unit.Save();
        }
    }
}