using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards.BusinessLogic;

public class DeckBuilder : IDeckBuilder
{
    private readonly ICardGenerator _cardGenerator;
    private readonly DeckDescriptor _deckDescriptor;

    public DeckBuilder(ICardGenerator cardGenerator, DeckDescriptor deckDescriptor)
    {
        _deckDescriptor = deckDescriptor;
        _cardGenerator = cardGenerator;
    }

    public Deck CreateDeck()
    {
        var cards = _cardGenerator.Generate(_deckDescriptor);
        return new Deck(cards);
    }
}