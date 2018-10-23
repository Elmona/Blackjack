using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class DealerWinsOnEqualStrategy : IWhoWinGameEqualValueStrategy
    {

        public bool IsWinner(int DealerScore, int PlayerScore)
        {
            if (DealerScore == PlayerScore)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
