using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    class Greed
    {
        /* RULES:
          
            A single one (100)
            A single five (50)
            Triple ones [1,1,1] (1000)
            Triple twos [2,2,2] (200)
            Triple threes [3,3,3] (300)
            Triple fours [4,4,4] (400)
            Triple fives [5,5,5] (500)
            Triple sixes [6,6,6] (600)

            Four-of-a-kind (Multiply Triple Score by 2)
            Five-of-a-kind (Multiply Triple Score by 4)
            Six-of-a-kind (Multiply Triple Score by 8)

            Three Pairs [2,2,3,3,4,4] (800)

            Straight [1,2,3,4,5,6] (1200)
         */

        public Greed()
        { }

        public int Score(List<int> dice)
        {
            int score = 0;

            if(this.CheckIfRollIsValid(dice))
            {
                int scoreFromSingles = this.GetScoreFromSingles(dice);
                int scoreFromTriples = this.GetScoreFromTriples(dice);

                score = 
                        scoreFromSingles +
                        scoreFromTriples;
            }

            return score;
        }

        private bool CheckIfRollIsValid(List<int> dice)
        {
            if(dice == null ||
                dice.Count == 0 ||
                dice.Count > 6)
            {
                return false;
            }
            else if (dice.Any(d => d < 1 || d > 6))
            {
                return false;
            }

            return true;
        }

        private int GetScoreFromSingles(List<int> dice)
        {
            int score = 0;

            List<int> ones = dice.Where(d => d == 1).ToList();
            List<int> fives = dice.Where(d => d == 5).ToList();

            if (ones.Count == 1)
            {
                score += 100;
            }

            if (fives.Count == 1)
            {
                score += 50;
            }

            return score;
        }

        private int GetScoreFromTriples(List<int> dice)
        {
            int score = 0;

            var groups = dice.GroupBy(x => x);
            foreach(var group in groups.Where(g => g.Count() >=3 && g.Count() < 6))
            {
                if (group.Key == 1)
                {
                    score += 1000;
                }
                else if (group.Key > 1)
                {
                    score += (group.Key * 100);
                }                
            }

            return score;
        }
    }
}
