using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Deck deck1 = new Deck();

            deck1.PrintCards();
            deck1.Shuffle();
            deck1.PrintCards();

            Console.Read();

        }
    }
}
