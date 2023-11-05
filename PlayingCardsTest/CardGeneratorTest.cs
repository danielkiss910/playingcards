using Codecool.PlayingCards.BusinessLogic;
using Codecool.PlayingCards.Logging;
using Codecool.PlayingCards.Model;

namespace PlayingCardsTest;

[TestFixture]
public class CardGeneratorTest
{
    private ILogger _logger;
    private CardGenerator _cardGenerator;
    private int[] _numbers;
    private string[] _symbols;
    private string[] _suits;
    private DeckDescriptor _deckDescriptor;


    [SetUp] // Runs before each test
    public void Setup()
    {
        // Arrange
        _logger = new ConsoleLogger();
        _cardGenerator = new CardGenerator(_logger);
        _numbers = new[] { 2, 3, 4 };
        _symbols = new[] { "J", "Q", "K" };
        _suits = new[] { "Hearts, Diamonds" };
        _deckDescriptor = new DeckDescriptor(_numbers, _symbols, _suits);
    }
    
    
    [Test]
    public void GenerateCardsReturnsExpectedNumberOfCards()
    {
        // Arrange
        var expectedCardCount =
                _numbers.Length * _suits.Length * _symbols.Length;
        
        // Act
        var cards = _cardGenerator.Generate(_deckDescriptor);
        
        // Assert
        Assert.That(cards.Count(), Is.EqualTo(expectedCardCount));
    }


    [Test]
    public void GenerateCardsReturnsAllPossibleCards()
    {
        // Arrange
        var expectedCards = _suits.SelectMany(suit =>
            _numbers.Select(number => new Card(number.ToString(), suit))
                .Concat(_symbols.Select(symbol => new Card(symbol, suit)))).ToList();
        
        // Act
        var cards = _cardGenerator.Generate(_deckDescriptor).ToList();
        
        // Assert
        CollectionAssert.AreEquivalent(expectedCards, cards);
    }


    [Test]
    public void GenerateCardsDeckDescriptorIsNullReturnsEmptyList()
    {
        // Act 
        var cards = _cardGenerator.Generate(null);
        
        // Assert
        CollectionAssert.IsEmpty(cards);
    }
}