using System;
using System.Collections.Generic;

// Enum representing the four suits of a deck of cards
public enum Suit
{
    Heart,
    Square,
    Cross,
    Spade
}

// Enum representing the values of the cards
public enum Value
{
    Ace = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public class Card
{   
    // properties
    public Suit Suit { get; }
    public Value Value { get; }

    // constructor to initialize a card with a specific suit and value
    public Card(Suit suit, Value value)
    {
        Suit = suit;
        Value = value;
    }

    // override ToString() method to return a string representation of the card
    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}

public class CardDeck
{   
    private List<Card> cards; // list to store the cards in the deck

    // constructor to initialize a new deck of cards
    public CardDeck()
    {
        cards = new List<Card>(); // initialize the list of cards
        InitializeDeck(); // call method to populate the deck with cards
    }

    // method to populate the deck with cards
    private void InitializeDeck()
    {
        // loop through each suit and value to create all possible cards
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Value value in Enum.GetValues(typeof(Value)))
            {
                cards.Add(new Card(suit, value)); // create a new card and add it to the deck
            }
        }
    }

    // shuffle the cards in the deck
    public void Shuffle()
    {
        Random rng = new Random(); // create a new random number generator
        int n = cards.Count; // get the number of cards in the deck
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1); // generate a random index between 0 and n
            Card temp = cards[k]; // swap the card at index k with the card at index n
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }


    // print the content of the deck
    public void PrintDeck()
    {
        foreach (Card card in cards)
        {
            Console.WriteLine(card); 
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        CardDeck deck = new CardDeck(); // Create a new deck of cards
        Console.WriteLine("Original deck:");
        deck.PrintDeck(); // Print the content of the deck

        deck.Shuffle(); // Shuffle the deck
        Console.WriteLine("\nShuffled deck:");
        deck.PrintDeck(); // Print the shuffled deck
    }
}
