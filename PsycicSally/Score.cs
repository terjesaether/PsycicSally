using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsycicSally
{
    public struct Score
    {
        public Score(int guesses, double totalTime)
        {
            Guesses = guesses;
            TotalTime = totalTime;
        }
        public int Guesses;
        public double TotalTime;

        public override string ToString()
        {
            return string.Format("Guesses: {0}, Total time: {1}", Guesses, TotalTime);
        }
    }
}
