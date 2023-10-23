namespace Codecool.PlayingCards.Model;

public record Card(string Symbol, string Suit)
{
    public string Title => $"{Symbol} of {Suit}";

    public override string ToString()
    {
        return Title;
    }
}