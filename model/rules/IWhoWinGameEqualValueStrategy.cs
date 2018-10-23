using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IWhoWinGameEqualValueStrategy
    {
        bool IsWinner(int DealerScore, int PlayerScore);
    }
}
