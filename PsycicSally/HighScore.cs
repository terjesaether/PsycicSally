using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsycicSally
{
    public class HighScore
    {
        
        private static Dictionary<string, Score> scores = new Dictionary<string, Score>();

        public void AddScore(string name, Score score) {
            scores.Add(name, score);

            if (scores.Count > 10)
            {
                scores = scores
                    .OrderBy(s => s.Value.TotalTime)
                    .Take(10)
                    .ToDictionary(s => s.Key, s => s.Value);
            }
        }

        public bool IsScoreHighEnough(Score score)
        {
            if (scores.Count < 10)
            {
                return true;
            }

            return scores.Values
                .Any(s => s.TotalTime > score.TotalTime);
        }
    }
}
