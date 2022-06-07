using BLL;
using Xunit;

namespace Tests
{
    public class Tests
    {
        private readonly Service _service;

        public Tests()
        {
            _service = new Service();
        }

        [Fact]
        public void GetUser_ShoudlReturnExistingUser()
        {
            // Arrange
            var login = "email@gmail.com";
            var password = "123";

            // Act
            var user = _service.GetUser(login, password);

            // Assert
            Assert.Contains(login, user.Login);
            Assert.Contains(password, user.Password);
        }

        [Fact]
        public void GetBookById_ShouldReturnExistingBook()
        {
            // Arrange
            var bookId = 1;

            // Act
            var book = _service.GetBookById(bookId);

            // Assert
            Assert.Equal(bookId, book.BookId);
        }

        [Fact]
        public void GetAll_ShouldNotBeEmpty()
        {
            // Act
            var books = _service.GetAll();

            // Assert
            Assert.NotEmpty(books);
        }

        [Fact]
        public void GetGenres_ShouldNotBeEmpty()
        {
            // Act
            var genres = _service.GetGenres();

            // Assert
            Assert.NotEmpty(genres);
        }

        [Fact]
        public void GetTypes_ShouldNotBeEmpty()
        {
            // Act
            var types = _service.GetTypes();

            // Assert
            Assert.NotEmpty(types);
        }

        [Fact]
        public void GetBooks_ShouldNotBeEmpty()
        {
            // Arrange
            var genre = "Genre";
            var type = "Type";
    
            // Act
            var books = _service.GetBooks(genre, type);

            // Assert
            Assert.NotEmpty(books);
        }
    }
}