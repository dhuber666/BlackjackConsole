using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class BlackjackDeck : Deck
    {

        public List<Deck> Decks { get; private set; }
        public List<Card> FullDeck { get; private set; }
        private Random rng;


        public BlackjackDeck(int deckCount)
        {
            FullDeck = new List<Card>();
            rng = new Random();
            
            for (int i = 0; i < deckCount; i++)
            {
                Deck tempDeck = new Deck();
                FullDeck.AddRange(tempDeck.Cards);
            }

            
            
        }

        public void CardCount()
        {
            Console.WriteLine("There are {0} remaining cards in the deck", FullDeck.Count());
        }

        public Card GetFirstCard()
        {
            Card temp = FullDeck[0]; // gets the first card from the list and save it into a variable
            if (temp.Value > 10)
                temp.Value = 10;
            FullDeck.Remove(temp); // removes the card from the list
            return temp; // returns the card drawn

        }

       
        public Card GetRandomCard()
        {
            Card temp = FullDeck[rng.Next(0, Cards.Count())];
            FullDeck.Remove(temp);
            return temp;
        }



    }
}
