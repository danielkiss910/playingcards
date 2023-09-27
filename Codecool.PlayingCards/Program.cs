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
}

// General method to generate a deck of cards based on provided parameters
public class Program
{
    private static Card[] GenerateDeck(int count, int[] numbers, string[] symbols, string[] suits)
    {
        Card[] deck = new Card[count];
        int index = 0;

        foreach (var suit in suits)
        {
            AddNumberedCards(deck, numbers, ref index, suit); // Add numbered cards to the deck
            AddCourtCards(deck, symbols, ref index, suit); // Add court cards to the deck
        }

        return deck;
    }
    
    // Method to add numbered cards to the deck
    private static void AddNumberedCards(Card[] deck, int[] numbers, ref int index, string suit) // add `ref` to avoid index overriding problem
    {
        foreach (var number in numbers) // Generate the numbered cards
        {
            Card card = new Card(number.ToString(), suit); // Create new card
            deck[index] = card; // Insert the card in the deck
            index++; // Increase the index
        }
    }
    
    // Method to add court cards to the deck (King, Queen etc)
    private static void AddCourtCards(Card[] deck, string[] symbols, ref int index, string suit)
    {
        foreach (var symbol in symbols)
        {
            Card card = new Card(symbol, suit); // Same steps as above
            deck[index] = card;
            index++;
        }
    }
    
    // Specific method to generate a standard French deck of 52 cards 
    private static Card[] GenerateFrenchDeck()
    {
        int[] numbers = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[] symbols = { "Jack", "Queen", "King", "Ace" };
        string[] suits = { "Clubs", "Spades", "Hearts", "Diamonds" };

        return GenerateDeck(52, numbers, symbols, suits);
    }
    
    // Specific method to generate a German deck of 32 cards
    private static Card[] GenerateGermanDeck()
    {
        int[] numbers = { 7, 8, 9, 10 };
        string[] symbols = { "Unter", "Ober", "King", "Ace" };
        string[] suits = { "Acorns", "Leaves", "Hearts", "Bells" };

        return GenerateDeck(32, numbers, symbols, suits);
    }
    
    // Method to print all cards in the provided deck to the console
    private static void PrintDeck(Card[] deck)
    {
        for (int i = 0; i < deck.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {deck[i]}");
        }
    }
    
    // Main method, entry point of the application
    public static void Main(string[] args)
    {
        Card[] frenchDeck = GenerateFrenchDeck();
        Card[] germanDeck = GenerateGermanDeck();
        
        // Print the French deck
        Console.WriteLine("French deck:");
        PrintDeck(frenchDeck);
        Console.WriteLine("----------");
        
        Console.WriteLine(Environment.NewLine); // Prints empty line
        
        // Print the German deck
        Console.WriteLine("German deck:");
        PrintDeck(germanDeck);
        
        // Wait for a key press before program exits
        Console.ReadKey();
    }
}