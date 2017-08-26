using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class Player
    {

        public List<Card> Hand { get; private set; }
        public bool PlayerLost { get => _playerLost; set => _playerLost = value; }

        private string _name;
        private bool _playerLost = false;


        public Player(string name)

        {
            // at first the player has just an empty hand:
            Hand = new List<Card>();
            _name = name;
        }

        public void DisplayHand()
        {
            int totalValue = 0;
     
            foreach (Card card in Hand)
            {
                Console.Write("{0} - {1} and ",card.Value, card.Color);
                totalValue += card.Value;
            }

            Console.WriteLine("-->Total value of {0}<--", totalValue);
        }

        // shows name of player

        public string GetPlayerName()
        {
            return _name;
        }

        public int ComputeValue()
        {
            int valueTotal = 0;

            foreach (Card card in Hand)
            {
                valueTotal += card.Value;
            }

            return valueTotal;
        }

        

        

    }
}
