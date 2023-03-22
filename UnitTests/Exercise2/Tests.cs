using ConsoleApp1.Exercise2;

namespace TestProject1.Exercise2;

public class Tests
{
    private Library _library;
    
    [SetUp]
    public void Init()
    {
        _library = new Library();

        _library.TryCreateMember("Obi-Wan Kenobi");
        _library.TryCreateMember("Anakin Skywalker");
        _library.TryCreateMember("Yoda");
        _library.TryCreateMember("Count Dooku");

        var book1 = new Book
        {
            Author = "J. R. R. Tolkien",
            Title = "Lord of the Rings",
        };

        var book2 = new Book
        {
            Author = "Margaret Mitchell",
            Title = "Gone With the Wind"
        };

        var book3 = new Book
        {
            Author = "J. K. Rowling",
            Title = "Harry Potter"
        };

        _library.TryAddBook(book1);
        _library.TryAddBook(book2);
        _library.TryAddBook(book3);
    }

    [TearDown]
    public void Cleanup()
    {
        _library = new Library();
    }
    
    [Test]
    public void AddRandomMembers()
    {
        var name1 = "Johnny Walker";
        _library.TryCreateMember(name1);
        Assert.That(_library.TryGetMember(name1), Is.True);
    }

    [Test]
    public void AddingMemberWhoseExistsShouldBeFalse()
    {
        var name1 = "Anakin Skywalker";
        Assert.That(_library.TryCreateMember(name1), Is.False);
    }
    
    [Test]
    public void MemberWantsToBorrowBook()
    {
        var memberName = "Anakin Skywalker";
        var wantedTitle = "Harry Potter";
        var wantedAuthor = "J. K. Rowling";
        
        var cardId = _library.GetMembersCardId(memberName);
        var bookExists = _library.TryGetBook(out var book, wantedTitle, wantedAuthor);

        var assigningCompleted = _library.TryAssignBookToCard(cardId, book);
        
        Assert.Multiple(() =>
        {
            Assert.That(bookExists, Is.True);
            Assert.That(assigningCompleted, Is.True);
            Assert.That(cardId, Is.EqualTo(1));
        });
    }

    [Test]
    public void MemberWantsToBorrowBookJustByTitle()
    {
        var memberName = "Anakin Skywalker";
        var wantedTitle = "Lord of the Rings";
        
        var cardId = _library.GetMembersCardId(memberName);
        var bookExists = _library.TryGetBook(out var book, wantedTitle);

        var assigningCompleted = _library.TryAssignBookToCard(cardId, book);
        
        Assert.Multiple(() =>
        {
            Assert.That(bookExists, Is.True);
            Assert.That(assigningCompleted, Is.True);
            Assert.That(cardId, Is.EqualTo(1));
        });
    }

    [Test]
    public void MemberWantsToReturnBook()
    {
        var memberName = "Anakin Skywalker";
        var wantedTitle = "Lord of the Rings";
        
        var cardId = _library.GetMembersCardId(memberName);
        var bookExists = _library.TryGetBook(out var book, wantedTitle);
        
        var result = _library.TryReturnBook(cardId, book);
        
        Assert.Multiple(() =>
        {
            Assert.That(bookExists, Is.True);
            Assert.That(result, Is.True);
            Assert.That(cardId, Is.EqualTo(1));
        });
    }

    [Test]
    public void SomeoneWhoIsNotMemberWantsToBorrowBook()
    {
        var memberName = "Jeremy Irons";
        var wantedTitle = "Lord of the Rings";
        
        var cardId = _library.GetMembersCardId(memberName);
        var bookExists = _library.TryGetBook(out var book, wantedTitle);
        
        var assigningCompleted = _library.TryAssignBookToCard(cardId, book);
        
        Assert.Multiple(() =>
        {
            Assert.That(bookExists, Is.True);
            Assert.That(assigningCompleted, Is.False);
            Assert.That(cardId, Is.EqualTo(-1));
        });
    }

    [Test]
    public void MemberWantsToBorrowNonexistentBook()
    {
        var memberName = "Anakin Skywalker";
        var wantedTitle = "Europe";
        var wantedAuthor = "Norman Davies";
        
        var cardId = _library.GetMembersCardId(memberName);
        var bookExists = _library.TryGetBook(out var book, wantedTitle, wantedAuthor);
        
        var assigningCompleted = _library.TryAssignBookToCard(cardId, book);
        
        Assert.Multiple(() =>
        {
            Assert.That(bookExists, Is.False);
            Assert.That(assigningCompleted, Is.False);
            Assert.That(cardId, Is.EqualTo(1));
        });
    }
}