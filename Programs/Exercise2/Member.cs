namespace ConsoleApp1.Exercise2;

public class Member
{
    public string Name { get; set; }
    private Card _card;

    public Member(string name, Card card)
    {
        Name = name;
        _card = card;
    }

    public int GetCardId()
    {
        return _card.Id;
    }

    public void AssignBook(Book book)
    {
        _card.AddBook(book);
    }
}