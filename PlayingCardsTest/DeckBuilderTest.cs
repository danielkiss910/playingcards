using Moq;

namespace PlayingCardsTest;

using Codecool.PlayingCards.BusinessLogic;
using Codecool.PlayingCards.Model;
using Codecool.PlayingCards.Logging;

[TestFixture]
public class DeckBuilderTest
{
    private Mock<ICardGenerator> _cardGeneratorMock;
    private DeckDescriptor _deckDescriptor;

    [SetUp]
    public void SetUp()
    {
        _cardGeneratorMock = new Mock<ICardGenerator>();
        _deckDescriptor = new DeckDescriptor(Array.Empty<int>(), Array.Empty<string>(), Array.Empty<string>());
    }

    [Test]
    public void CreateDeck_ReturnsNewDeckWithGeneratedCards()
    {
        // Arrange
        var cards = new List<Card> { new("Ace", "Spades"), new Card("Ace", "Hearts") };
        _cardGeneratorMock.Setup(x => x.Generate(_deckDescriptor)).Returns(cards.ToList());
        var deckBuilder = new DeckBuilder(_cardGeneratorMock.Object, _deckDescriptor);
        
        // Act
        var deck = deckBuilder.CreateDeck();
        
        // Assert
        var drawn = deck.DrawOne();
        while (drawn != null)
        {
            Assert.That(cards, Does.Contain(drawn));
            drawn = deck.DrawOne();
        }
    }
}