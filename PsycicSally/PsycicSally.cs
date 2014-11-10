using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class PsycicSally
    {
        int numberToGuess;
        int numberOfGuesses;
        bool isRunning;

        public bool IsRunning
        { 
            get { return isRunning; } 
        }

        public PsycicSally()
        {
        }

        public void Start()
        {
            numberOfGuesses = 0;
            isRunning = true;

            var random = new Random();

            numberToGuess = random.Next(0, 100);

            Console.WriteLine("Game started.");
        }

        public GuessResult MakeNewGuess()
        {
            numberOfGuesses++;

            GuessResult result = Guess();

            PrintResult(result);

            if (result == GuessResult.Correct)
            {
                isRunning = false;
            }
            
            return result;
        }

        public void PrintResult(GuessResult result)
        {
            switch (result)
            {
                case GuessResult.TooHigh:
                    Console.WriteLine("Too high! Aim lower.");
                    break;
                case GuessResult.TooLow:
                    Console.WriteLine("Too low! Aim higher.");
                    break;
                case GuessResult.Correct:
                    Console.WriteLine("Wow. You are really a psycic! You managed to guess the magic number in " + numberOfGuesses + " guesses");
                    break;
                default:
                    throw new NotSupportedException("GuessResult '" + result.ToString() + "' is not supported.");
            }

        }

        private GuessResult Guess()
        {
            Console.WriteLine("Guess a number between 0 and 100:");

            int guessedNumber = int.Parse(Console.ReadLine());
            int guessResult = guessedNumber.CompareTo(numberToGuess);

            var result = (GuessResult)guessResult;

            return result;

        }
    }
}
