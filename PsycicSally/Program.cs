using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new PsycicSally();

            game.Start();

            while (game.IsRunning)
            {
                game.MakeNewGuess();
            }

            Console.ReadKey();
        }
    }
}
