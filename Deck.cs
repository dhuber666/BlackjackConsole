using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class Deck // this class contains an array of cards (52 in total)
    {

        public List<Card> Cards { get; set; } = new List<Card>();
        private const int _maxCards = 52;
        Random rng;
        

        public Deck()
        {

            // put 52 cards into the deck.
            rng = new Random();
            

            foreach (var color in Enum.GetValues(typeof(CardColor))) // TODO Add also add the cards King, Queen, Junge (which also have values of 10)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Cards.Add(new Card((CardColor)color, i));
                }
            }

            foreach (var color in Enum.GetValues(typeof(CardColor)))
            {


                Console.WriteLine(color);

            }

            
        

        }

        

        public void PrintCards()

        {
            foreach (var card in Cards)
            {
                Console.WriteLine("The card's color is: {0} and the value is {1}", card.Color, card.Value);
            }
        }

        public static void Shuffle<T>(this IList<T> ts)
        {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = rng.Next(i, count); // TODO Auch hier Otto fragen wieso das nicht funktioniert
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }

        
    }
}
