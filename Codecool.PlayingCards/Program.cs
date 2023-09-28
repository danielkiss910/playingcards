using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards.Model // Namespaces are used to organize code into logical groups
{
    // Class to represent a card, with properties for its symbol, suit, and a title
    public class Card
    {
        public string Suit { get; }
        public string Symbol { get; }
        public string Title { get; }
        
        // Constructor for the Card class
        public Card(string symbol, string suit)
        {
            Suit = suit;
            Symbol = symbol;
            Title = $"{Symbol} of {Suit}";
        }
        
        // Override the ToString method to display the card's title
        public override string ToString()
        {
            return Title; 
        }
        
        // Equality overriding methods (built in) to compare 2 cards based on their suit and symbol
        // Right click -> generate -> equality members -> suit, symbol
        protected bool Equals(Card other)
        {
            return Suit == other.Suit && Symbol == other.Symbol;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Suit, Symbol);
        }
    }
    
    // Deck class
    public class Deck
    {
        private static readonly Random Random = new Random();
        
        private readonly List<Card> _cards; // readonly - can assign value to it only once
        private readonly List<Card> _drawn;

        public int CardCount => _cards.Count;

        public Deck(List<Card> cards)
        {
            _cards = cards;
            _drawn = new List<Card>();
        }

        public Card? DrawOne()
        {
            Card card = _cards[Random.Next(0, _cards.Count - 1)];
            HandleDraw(card);
            return card;
        }

        private void HandleDraw(Card card)
        {
            _cards.Remove(card);
            _drawn.Add(card);
        }

        public void Reset()
        {
            List<Card> current = new List<Card>(_cards);
            _cards.Clear();
            _cards.AddRange(current.Concat(_drawn));
        }
    }
}

// General method to generate a deck of cards based on provided parameters
public class Program
{
    // Main method, entry point of the application
    public static void Main(string[] args)
    {
        Deck frenchDeck = GenerateFrenchDeck();
        Console.WriteLine($"French deck created. Card count: {frenchDeck.CardCount}");

        Card frenchCard = frenchDeck.DrawOne();
        Console.WriteLine($"{frenchCard} was drawn. Card count: {frenchDeck.CardCount}");
        
        frenchDeck.Reset();
        Console.WriteLine($"Deck has been reset. Card count: {frenchDeck.CardCount}");
        
        
        Deck germanDeck = GenerateGermanDeck();
        Console.WriteLine($"German deck created. Card count: {germanDeck.CardCount}");

        Card germanCard = germanDeck.DrawOne();
        Console.WriteLine($"{germanCard} was drawn. Card count: {germanDeck.CardCount}");
        
        germanDeck.Reset();
        Console.WriteLine($"Deck has been reset. Card count: {germanDeck.CardCount}");
        
        // Wait for a key press before program exits
        Console.ReadKey();
    }
    
    // Specific method to generate a standard French deck of 52 cards 
    private static Deck GenerateFrenchDeck()
    {
        int[] numbers = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] symbols = { "Jack", "Queen", "King", "Ace" };
        string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };

        return GenerateDeck(numbers, symbols, suits);
    }
    
    // Specific method to generate a German deck of 32 cards
    private static Deck GenerateGermanDeck()
    {
        int[] numbers = { 7, 8, 9, 10 };
        string[] symbols = { "Unter", "Ober", "King", "Ace" };
        string[] suits = { "Acorns", "Leaves", "Hearts", "Bells" };

        return GenerateDeck(numbers, symbols, suits);
    }
    
    private static Deck GenerateDeck(int[] numbers, string[] symbols, string[] suits)
    {
        List<Card> cards = new List<Card>();

        foreach (var suit in suits)
        {
            AddNumberedCards(cards, numbers, suit); // Add numbered cards to the cards
            AddCourtCards(cards, symbols, suit); // Add court cards to the cards
        }

        return new Deck(cards);
    }
    
    // Method to add numbered cards to the deck
    private static void AddNumberedCards(List<Card> cards, int[] numbers, string suit) // add `ref` to avoid index overriding problem
    {
        foreach (var number in numbers) // Generate the numbered cards
        {
            Card card = new Card(number.ToString(), suit); // Create new card
            cards.Add(card); // Add card to cards list
        }
    }
    
    // Method to add court cards to the deck (King, Queen etc)
    private static void AddCourtCards(List<Card> cards, string[] symbols, string suit)
    {
        foreach (var symbol in symbols)
        {
            Card card = new Card(symbol, suit); // Same steps as above
            cards.Add(card);
        }
    }
    
    // Method to print all cards in the provided deck to the console
    private static void PrintDeck(Card[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {deck[i]}");
        }
    }
}