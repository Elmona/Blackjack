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
            int score = a_dealer.CalcScore();

            foreach (Card c in a_dealer.GetHand())
            {

                if (score == 17 && c.GetValue() == Card.Value.Ace)
                {
                    Console.WriteLine("Dealer got Soft17!");
                    return score < g_softHitLimit;
                }
            }

            return score < g_hardHitLimit;
        }

    }
}

