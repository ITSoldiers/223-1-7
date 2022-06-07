namespace BLL.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Type { get; set; }

        public BookDTO(int BookId, string Title, string Author, string Genre, string Type)
        {
            this.BookId = BookId;
            this.Title = Title;
            this.Author = Author;
            this.Genre = Genre;
            this.Type = Type;
        }
    }
}
