using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class Deck // this class contains an array of cards (52 in total)
    {

        public List<Card> Cards { get;  set; } = new List<Card>();
        private const int _maxCards = 52;
        Random rng;
        
        public Deck()
        {

            // put 52 cards into the deck.
            rng = new Random();

            foreach (var color in Enum.GetValues(typeof(CardColor))) // TODO Add also add the cards King, Queen, Junge (which also have values of 10)
            {
                for (int i = 1; i <= 14; i++)
                {
                    Cards.Add(new Card((CardColor)color, i));
                }
            }

           
        }

        

        public void PrintCards()

        {
            foreach (var card in Cards)
            {
                Console.WriteLine("The card's color is: {0} and the value is {1}", card.Color, card.Value);
            }
        }

        //public virtual Card GetFirstCard()
        //{
        //    Card temp = Cards[0]; // gets the first card from the list and save it into a variable
        //    Cards.Remove(temp); // removes the card from the list
        //    return temp; // returns the card drawn

        //}

        //public virtual Card GetRandomCard()
        //{
        //    Card temp = Cards[rng.Next(0, Cards.Count())];
        //    Cards.Remove(temp);
        //    return temp;
        //}
    }
}
