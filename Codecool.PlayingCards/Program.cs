using Codecool.PlayingCards.Model;
using Codecool.PlayingCards.BusinessLogic;
using Codecool.PlayingCards.Logging;

namespace Codecool.PlayingCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            ICardGenerator cardGenerator = new CardGenerator(logger);

            IDeckBuilder frenchDeckBuilder = new DeckBuilder(cardGenerator, DeckDescriptors.FrenchDeckDescriptor);
            IDeckBuilder germanDeckBuilder = new DeckBuilder(cardGenerator, DeckDescriptors.GermanDeckDescriptor);

            List<Deck> decks = BuildDecks(new[] { frenchDeckBuilder, germanDeckBuilder });

            PrintCardCounts(decks.ToArray());
        }

        private static List<Deck> BuildDecks(IDeckBuilder[] builders)
        {
            List<Deck> decks = new List<Deck>();

            foreach (IDeckBuilder builder in builders)
            {
                decks.Add(builder.CreateDeck());
            }

            return decks;
        }

        private static void PrintCardCounts(Deck[] decks)
        {
            foreach (Deck deck in decks)
            {
                Console.WriteLine(deck.CardCount);
            }
        }
    }
}