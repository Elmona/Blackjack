using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int score = a_dealer.CalcScore();

            if (score > g_hitLimit && score < 22) 
            {
                return false;
            }

            return score < g_hitLimit;
        }

    }
}
