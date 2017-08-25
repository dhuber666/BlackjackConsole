using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole


{

    public enum CardColor
    {
        Club = 0,
        Diamond = 1,
        Hearth = 2,
        Spade = 3
    }

    class Card // this is the class that creates card objects (an array or list of that will later be stored into the deck class)
    {

        

        public CardColor Color{get; set;}

        public int Value { get; set; }

        public Card(CardColor cardColor, int value)
        {
            Color = cardColor;
            Value = value;
        }

        

    }
}
