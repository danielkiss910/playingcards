namespace Codecool.PlayingCards.BusinessLogic;

using Model;
using Logging;

public class CardGenerator : ICardGenerator // `:` symbol declares implementation here
{
    private readonly ILogger _logger;

    public CardGenerator(ILogger logger)
    {
        _logger = logger;
    }

    public IEnumerable<Card> Generate(DeckDescriptor descriptor)
    {
        foreach (var suit in descriptor.Suits)
        {
            foreach (var number in descriptor.Numbers)
            {
                yield return CreateCard(number.ToString(), suit);
            }

            foreach (var symbol in descriptor.Symbols)
            {
                yield return CreateCard(symbol, suit);
            }
        }
    }
    
    private Card CreateCard(string symbol, string suit)
    {
        Card card = new Card(symbol, suit);
        _logger.LogInfo($"Generated card {card}");
        return card;
    }
}