using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards.Model
{
    public enum Suit
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades,
    }

    public class Card
    {
        public Suit Suit { get; }
        public string Symbol { get; }
        public string Title { get; }
        
        public Card(string symbol, Suit suit)
        {
            Suit = suit;
            Symbol = symbol;
            Title = $"{Symbol} of {Suit}";
        }
        
        // Equality overriding (built in)
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
            return HashCode.Combine((int)Suit, Symbol);
        }
        
        // ToString() overriding to return `Ace of Spades` instead of `Codecool.PlayingCards.Model`
        public override string ToString()
        {
            return Title; 
        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Card[] deck = GenerateFrenchDeck();

        for (int i = 0; i < deck.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {deck[i]}");
        }
        
        Console.ReadKey(); // This ensure the program does not exit immediately after execution but waits for a keystroke
    }
    
    // AddNumberedCards method
    private static void AddNumberedCards(Card[] deck, ref int index, Suit suit) // add `ref` to avoid index overriding problem
    {
        for (int i = 2; i <= 10; i++) // Generate the numbered cards
        {
            Card card = new Card(i.ToString(), suit); // Create new card
            deck[index] = card; // Insert the card in the deck
            index++; // Increase the index
        }
    }
    
    // AddCourtCards method
    private static void AddCourtCards(Card[] deck, ref int index, Suit suit)
    {
        string[] courtSymbols = { "Jack", "Queen", "King", "Ace" }; // Generate the court cards
        
        foreach (var courtSymbol in courtSymbols)
        {
            Card card = new Card(courtSymbol, suit); // Same steps as above
            deck[index] = card;
            index++;
        }
    }
    
    // GenerateFrenchDeck method using above 2 methods for improved readability
    private static Card[] GenerateFrenchDeck()
    {
        Card[] deck = new Card[52]; // Create empty array of 52 elements
        
        int index = 0; // Create an index
        
        foreach (var suit in Enum.GetValues<Suit>()) // Iterate over the suits
        {
            AddNumberedCards(deck, ref index, suit); // Add `ref` here as well to avoid index overriding problem
            AddCourtCards(deck, ref index, suit);
        }
        
        return deck;
    }
}