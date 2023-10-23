namespace Codecool.PlayingCards.Model;

public class Deck
{
    private static readonly Random Random = new Random();
        
    private readonly List<Card> _cards; // readonly - can assign value to it only once
    private readonly List<Card> _drawn;

    public int CardCount => _cards.Count;

    public Deck(List<Card> cards)
    {
        _cards = cards;
        _drawn = new List<Card>();
    }

    public Card DrawOne()
    {
        Card card = _cards[Random.Next(0, _cards.Count - 1)];
        HandleDraw(card);
        return card;
    }

    private void HandleDraw(Card card)
    {
        _cards.Remove(card);
        _drawn.Add(card);
    }

    public void Reset()
    {
        _cards.AddRange(_drawn);
        _drawn.Clear();
    }
}