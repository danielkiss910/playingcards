using Codecool.PlayingCards.Model;
using Codecool.PlayingCards.Logging;

namespace Codecool.PlayingCards.BusinessLogic;

public class CardGenerator : ICardGenerator // `:` symbol declares implementation here
{
    private readonly ILogger _logger;

    public CardGenerator(ILogger logger)
    {
        _logger = logger;
    }

    public List<Card> Generate(DeckDescriptor descriptor)
    {
        List<Card> cards = new List<Card>();

        foreach (var suit in descriptor.Suits)
        {
            foreach (var number in descriptor.Numbers)
            {
                AddCards(cards, number.ToString(), suit);
            }

            foreach (var symbol in descriptor.Symbols)
            {
                AddCards(cards, symbol, suit);
            }
        }

        return cards;
    }
    
    private void AddCards(List<Card> cards, string symbol, string suit)
    {
        Card card = new Card(symbol, suit);
        _logger.LogInfo($"Generated card {card}");
        cards.Add(card);
    }
}