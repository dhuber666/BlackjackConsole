using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackConsole
{
    public static class ShuffleExtension
    {

        static Random rng = new Random();


        public static void Shuffle<T>(this IList<T> ts) // Fisher-Yates shuffle algorythm
        {
            var count = ts.Count;
            var last = count - 1;
            for (var i = 0; i < last; ++i)
            {
                var r = rng.Next(i, count); 
                var tmp = ts[i];
                ts[i] = ts[r];
                ts[r] = tmp;
            }
        }



    }
}
