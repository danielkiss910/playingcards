using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards.BusinessLogic;

public interface ICardGenerator
{
    IEnumerable<Card> Generate(DeckDescriptor descriptor);
}