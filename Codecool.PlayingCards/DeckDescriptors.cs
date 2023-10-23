using Codecool.PlayingCards.Model;

namespace Codecool.PlayingCards;

public static class DeckDescriptors
{
    private static readonly int[] FrenchNumbers = { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    private static readonly string[] FrenchSymbols = { "Jack", "Queen", "King", "Ace" };
    private static readonly string[] FrenchSuits = { "Clubs", "Spades", "Hearts", "Diamonds" };
        
    private static readonly int[] GermanNumbers = { 7, 8, 9, 10 };
    private static readonly string[] GermanSymbols = { "Unter", "Ober", "King", "Ace" };
    private static readonly string[] GermanSuits = { "Acorns", "Leaves", "Hearts", "Bells" };

    public static readonly DeckDescriptor FrenchDeckDescriptor =
        new DeckDescriptor(FrenchNumbers, FrenchSymbols, FrenchSuits);

    public static readonly DeckDescriptor GermanDeckDescriptor =
        new DeckDescriptor(GermanNumbers, GermanSymbols, GermanSuits);
}