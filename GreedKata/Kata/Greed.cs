using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata
{
    class Greed
    {
        public Greed()
        { }

        public int Score(int[] diceValues)
        {
            if(this.CheckIfRollIsValid(diceValues))
            {
                List<int> ones = diceValues.Where(d => d == 1).ToList();
                if(ones.Count == 1)
                {
                    return 100;
                }
            }

            return 0;
        }

        private bool CheckIfRollIsValid(int[] diceValues)
        {
            if(diceValues == null ||
                diceValues.Length == 0 ||
                diceValues.Length > 6)
            {
                return false;
            }
            else if (diceValues.Any(d => d < 1 || d > 6))
            {
                return false;
            }

            return true;
        }
    }
}
