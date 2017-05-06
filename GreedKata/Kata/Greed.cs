﻿using System;
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

        public int Score(List<int> diceValues)
        {
            if(this.CheckIfRollIsValid(diceValues))
            {
                List<int> ones = diceValues.Where(d => d == 1).ToList();
                List<int> twos = diceValues.Where(d => d == 2).ToList();
                List<int> threes = diceValues.Where(d => d == 3).ToList();
                List<int> fours = diceValues.Where(d => d == 4).ToList();
                List<int> fives = diceValues.Where(d => d == 5).ToList();
                List<int> sixes = diceValues.Where(d => d == 6).ToList();

                if (ones.Count == 1)
                {
                    return 100;
                }
                if(ones.Count == 3)
                {
                    return 1000;
                }

                if(twos.Count == 3)
                {
                    return 200;
                }

                if (threes.Count == 3)
                {
                    return 300;
                }

                if(fours.Count ==3 )
                {
                    return 400;
                }
                                
                if(fives.Count == 1)
                {
                    return 50;
                }
                if(fives.Count == 3)
                {
                    return 500;
                }

                if (sixes.Count == 3)
                {
                    return 600;
                }
            }

            return 0;
        }

        private bool CheckIfRollIsValid(List<int> diceValues)
        {
            if(diceValues == null ||
                diceValues.Count == 0 ||
                diceValues.Count > 6)
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
