using BLL;
using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Service _service;
        public BooksController()
        {
            _service = new Service();
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<BookDTO> Get()
        {
            return _service.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{genre}/{type}")]
        public IEnumerable<BookDTO> Get(string genre, string type)
        {
            return _service.GetBooks(genre, type);
        }

        [HttpGet("Genres")]
        public IEnumerable<string?> GetGenres()
        {
            return _service.GetGenres();
        }

        [HttpGet("Types")]
        public IEnumerable<string?> GetTypes()
        {
            return _service.GetTypes();
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post(BookDTO book)
        {
            _service.AddBook(book);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteBookById(id);
        }
    }
}
