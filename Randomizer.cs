using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public class Randomizer
    {

        Random rng = new Random();

        public static int Next(int i, int j)
        {
            return rng.Next(i, j); // TODO Otto fragen wieso ich das nicht so machen kann


        }


    }
}
