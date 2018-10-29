using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class SoftHitStrategy : IHitStrategy
    {
        private const int g_hardHitLimit = 17;
        private const int g_softHitLimit = 21;

        public bool DoHit(model.Player a_dealer)
        {
            int dealerScoreAceLowered = a_dealer.CalcScore();
            int dealerScoreAceNotLowered = 0;
            int[] cardScores = new int[(int)model.Card.Value.Count]
               {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};

            foreach (Card c in a_dealer.GetHand())
            {
                dealerScoreAceNotLowered += cardScores[(int)c.GetValue()];

                if (dealerScoreAceNotLowered == 17 && c.GetValue() == Card.Value.Ace)
                {
                    return dealerScoreAceNotLowered < g_softHitLimit;
                }
            }

            return dealerScoreAceLowered < g_hardHitLimit;
        }

    }
}

