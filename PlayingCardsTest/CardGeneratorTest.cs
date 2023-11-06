using Codecool.PlayingCards.BusinessLogic;
using Codecool.PlayingCards.Logging;
using Codecool.PlayingCards.Model;

namespace PlayingCardsTest;

[TestFixture]
public class CardGeneratorTest
{
    private ILogger _logger;
    private CardGenerator _cardGenerator;

    [SetUp] // Runs before each test
    public void Setup()
    {
        // Arrange common setup
        _logger = new ConsoleLogger();
        _cardGenerator = new CardGenerator(_logger);
    }

    private static IEnumerable<TestCaseData> CardGeneratorTestCases
    {
        get
        {
            var numbers = new[] { 2, 3, 4 };
            var symbols = new[] { "J", "Q", "K" };
            var suits = new[] { "Hearts", "Diamonds" };

            yield return new TestCaseData(
                new DeckDescriptor(numbers, symbols, suits),
                numbers.Length * suits.Length + symbols.Length * suits.Length
            ).SetName("GenerateCardsReturnsExpectedNumberOfCards_WithDeckDescriptor");
        }
    }

    [Test, TestCaseSource(nameof(CardGeneratorTestCases))]
    public void GenerateCardsReturnsExpectedNumberOfCards(DeckDescriptor descriptor, int expectedCount)
    {
        var cards = _cardGenerator.Generate(descriptor);
        Assert.That(cards.Count(), Is.EqualTo(expectedCount));
    }

    [TestCase(new[] { 2, 3, 4 }, new[] { "J", "Q", "K" }, new[] { "Hearts", "Diamonds" })]
    public void GenerateCardsReturnsAllPossibleCards(int[] numbers, string[] symbols, string[] suits)
    {
        var descriptor = new DeckDescriptor(numbers, symbols, suits);
        var expectedCards = suits.SelectMany(suit =>
            numbers.Select(number => new Card(number.ToString(), suit))
                .Concat(symbols.Select(symbol => new Card(symbol, suit)))).ToList();

        var cards = _cardGenerator.Generate(descriptor).ToList();
        CollectionAssert.AreEquivalent(expectedCards, cards);
    }

    [Test]
    public void GenerateCardsDeckDescriptorIsNullThrowsException()
    {
        // Act & Assert
        var exception = Assert.Throws<ArgumentNullException>(() => _cardGenerator.Generate(null));
        Assert.That(exception.ParamName, Is.EqualTo("descriptor"));
    }

}
