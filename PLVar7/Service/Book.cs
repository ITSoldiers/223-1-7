using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Book
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int BookTypeId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Type { get; set; }

        public Book(int BookId, string Title, string Author, string Genre, string Type)
        {
            this.BookId = BookId;
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.Type = Type;
        }
    }
}
