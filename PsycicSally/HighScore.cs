using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsycicSally
{
    public class HighScore
    {
        private static int Size = 10;
        private class Scoring
        {
            private string name;
            private Score score;
            
            public Scoring(
                string name,
                Score score)
            {
                this.name = name;
                this.score = score;
            }
            
            public string Name { get { return name; } }
            public Score Score { get { return score; } }

            public override string ToString()
            {
                return string.Join(",", new string[]{name, score.Guesses.ToString(), score.TotalTime.ToString(CultureInfo.InvariantCulture)});
            }
            public static Scoring Parse(string s)
            {
                var arr = s.Split(',');
                var name = arr[0];
                var guesses = int.Parse(arr[1]);
                var totalTime = double.Parse(arr[2], CultureInfo.InvariantCulture);

                var score = new Score(guesses, totalTime);
                var scoring = new Scoring(name, score);

                return scoring;
            }
        }

        private static List<Scoring> scores = new List<Scoring>();

        public static void AddScore(
            string name,
            Score score)
        {
            scores.Add(new Scoring(name, score));

            ReorderAndResizeHighScoreList();
        }

        private static void ReorderAndResizeHighScoreList()
        {
            scores = scores
                .OrderBy(s => s.Score.Guesses)
                .ThenBy(s => s.Score.TotalTime)
                .Take(Size)
                .ToList();
        }

        public static bool IsScoreHighEnough(Score score)
        {
            if (HighScoreNotFull())
                return true;

            if (AnyScoreWithMoreGuesses(score))
                return true;

            if (AnyScoresWithLongerTime(score))
                return true;

            return false;
        }

        private static bool HighScoreNotFull()
        {
            return scores.Count < Size;
        }

        private static bool AnyScoreWithMoreGuesses(Score score)
        {
            return scores.Any(s => s.Score.Guesses > score.Guesses);
        }

        private static bool AnyScoresWithLongerTime(Score score)
        {
            return scores.Any(s =>
                s.Score.Guesses == score.Guesses &&
                s.Score.TotalTime > score.TotalTime);
        }

        public static void Print()
        {
            var text = ToHallOfFame();

            Console.WriteLine(text);
        }

        private static string ToHallOfFame()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("  -----------------------------  ");
            sb.AppendLine(" | Psycic Sally - Hall of Fame | ");
            sb.AppendLine(" |-----------------------------| ");
            for (int i = 0; i < scores.Count; i++)
            {
                var score = scores[i];
                sb.AppendFormat(
                    " | {0:00}. {1,-11}{2,4}{3,8:0.000} | ",
                    i + 1,
                    score.Name,
                    score.Score.Guesses,
                    score.Score.TotalTime);
                sb.AppendLine();
            }
            sb.AppendLine("  -----------------------------  ");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
