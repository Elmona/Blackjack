using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : NewGameStrategy
    {

        public override bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            AddCard(a_deck.GetCard(), a_player, true);
            AddCard(a_deck.GetCard(), a_dealer, true);
            AddCard(a_deck.GetCard(), a_player, true);

            return true;
        }
    }
}
