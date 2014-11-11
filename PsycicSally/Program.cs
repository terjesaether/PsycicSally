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

            bool playing = true;
            while (playing)
            {
                game.Start();

                Console.WriteLine();
                Console.WriteLine("Game finished. Press Esc to exit, any other key to continue");

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    playing = false;
                }
            }
        }
    }
}
