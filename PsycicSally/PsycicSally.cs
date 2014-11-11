using PsycicSally;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    public class PsycicSally
    {
        private int min = 1;
        private int max = 100;
        private int numberToGuess;
        private int guesses;
        private bool isRunning;
        private DateTime startTime;
        private DateTime endTime;

        public bool IsRunning
        { 
            get { return isRunning; } 
        }

        public PsycicSally()
        {
        }

        public void Start()
        {
            guesses = 0;
            isRunning = true;

            var random = new Random();

            numberToGuess = random.Next(min, max);

            startTime = DateTime.Now;

            Console.WriteLine("Game started.");

            while (IsRunning)
            {
                MakeNewGuess();
            }
        }

        public void Stop()
        {
            endTime = DateTime.Now;
            isRunning = false;
        }

        public void MakeNewGuess()
        {
            guesses++;

            GuessResult result = Guess();

            HandleResult(result);
        }

        public void HandleResult(GuessResult result)
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
                    Stop();
                    HandleCorrectGuess();
                    break;
                default:
                    var errorMessage = string.Format("GuessResult '{0}' is not supported.", result);
                    throw new NotSupportedException(errorMessage);
            }
        }

        private void HandleCorrectGuess()
        {
            var score = GetScore();
            Console.Write("Wow. You are really a psycic! ");
            Console.WriteLine(
                "You managed to guess the magic number in {0} guesses and {1} seconds.",
                score.Guesses,
                score.TotalTime);

            //TODO: Add to highscore if good enough
        }

        private Score GetScore()
        {
            DateTime totalTime;
            Score score = new Score();

            //TODO: Calculate total time and create score object
            return score;
        }

        private GuessResult Guess()
        {
            int guessedNumber = ReadGuessFromConsole();

            int guessResult = guessedNumber.CompareTo(numberToGuess);

            var result = (GuessResult) guessResult;

            return result;
        }

        private int ReadGuessFromConsole()
        {
            string input;
            int guessedNumber;
            do
            {
                Console.Write("Guess a number between {0} and {1}: ", min, max);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out guessedNumber));
            
            return guessedNumber;
        }
    }
}
