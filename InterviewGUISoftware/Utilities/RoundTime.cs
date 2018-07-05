using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewGUISoftware.Utilities
{
   public class RoundTime
    {
        public static int RoundToNearestTen(int numberToRound)
        {
            return ((int)Math.Round(numberToRound / 10.0)) * 10;
        }
    }
}
