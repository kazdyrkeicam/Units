namespace ConsoleApp1.Exercise2;

public class Library
{
    private List<Member> _members;
    private Dictionary<int, Book> _books;
    private HashSet<Card> _cards;
    private int _lastlyUsedCardId;
    private int _lastlyUsedBookId;

    public Library()
    {
        _members = new List<Member>();
        _books = new Dictionary<int, Book>();
        _cards = new HashSet<Card>();
        _lastlyUsedCardId = 0;
        _lastlyUsedBookId = 0;
    }

    public bool TryAssignBookToCard(int cardId, Book? book)
    {
        var card = _cards.FirstOrDefault(c => c.Id.Equals(cardId));
        if (card is null || book is null) return false;

        card.AddBook(book);
        return true;
    }

    public bool TryReturnBook(int cardId, Book? book)
    {
        var card = _cards.FirstOrDefault(c => c.Id.Equals(cardId));

        if (card is null || book is null) return false;
        card.TryRemoveBook(book);
        return true;
    }

    public bool TryAddBook(Book book)
    {
        if (_books.ContainsValue(book)) return false;
        
        _books.Add(_lastlyUsedBookId++, book);
        return true;
    }

    public bool TryCreateMember(string memberName)
    {
        if (TryGetMember(memberName)) return false;

        var card = new Card(_lastlyUsedCardId++);
        var newMember = new Member(memberName, card);
        
        _cards.Add(card);
        _members.Add(newMember);
        return true;
    }

    public bool TryGetBook(out Book? outBook, string title, string author)
    {
        outBook = _books.Values.FirstOrDefault(b => b.Author.Equals(author) && b.Title.Equals(title));

        return outBook is not null;
    }
    
    public bool TryGetBook(out Book? outBook, string title)
    {
        outBook = _books.Values.FirstOrDefault(b => b.Title.Equals(title));

        return outBook is not null;
    }

    public int GetMembersCardId(string name)
    {
        var member = _members.FirstOrDefault(m => m.Name.Equals(name));
        if (member is null) return -1;
        
        return member.GetCardId();
    }

    public bool TryGetMember(string name)
    {
        var member = _members.FirstOrDefault(m => m.Name.Equals(name));
        return member is not null;
    }
}