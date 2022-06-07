namespace Service
{
    public class DataBase
    {
        public List<Book> books = new List<Book>();

        public DataBase()
        {
            books.Add(new Book(0, "Book1", "Author1", "Fantasy", "Paper"));
            books.Add(new Book(1, "Book2", "Author2", "Detective", "Audio"));
            books.Add(new Book(2, "Book3", "Author3", "Horror", "Digital"));
            books.Add(new Book(3, "Book4", "Author4", "Detective", "Paper"));
            books.Add(new Book(4, "Book5", "Author5", "Novel", "Digital"));
            books.Add(new Book(5, "Book6", "Author6", "Adventure", "Paper"));
        }
    }
}
