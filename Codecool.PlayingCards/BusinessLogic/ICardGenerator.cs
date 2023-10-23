using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards.BusinessLogic;

public interface ICardGenerator
{
    List<Card> Generate(DeckDescriptor descriptor);
}