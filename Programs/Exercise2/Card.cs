namespace ConsoleApp1.Exercise2;

public class Card
{
    public int Id { get; set; }

    private HashSet<Book> _assignedBooks;

    public Card(int id)
    {
        Id = id;
        _assignedBooks = new HashSet<Book>();
    }
    
    public void AddBook(Book book)
    {
        _assignedBooks.Add(book);
    }

    public bool TryRemoveBook(Book? bookToRemove)
    {
        if (bookToRemove is null) return false;
        var book = _assignedBooks.FirstOrDefault(b => b.BookId == bookToRemove.BookId);

        if (book is null) return false;
        _assignedBooks.Remove(book);
        return true;
    }
}