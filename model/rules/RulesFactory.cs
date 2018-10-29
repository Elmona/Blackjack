using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            // return new BasicHitStrategy();
            return new SoftHitStrategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            //return new AmericanNewGameStrategy();
            return new InternationalNewGameStrategy();
        }

        public IWhoWinGameEqualValueStrategy GetWhoWinEqualRule()
        {
            return new DealerWinsOnEqualStrategy();
            // return new DealerLosesOnEqualStrategy();
            // return new IWhoWinGameEqualValueStrategy();
        }
    }
}
