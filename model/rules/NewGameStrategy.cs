using System;

namespace BlackJack.model.rules
{
    abstract class NewGameStrategy : INewGameStrategy
    {
        public abstract bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player);

        public void AddCard(Card a_card, Player a_player, bool show)
        {
            a_card.Show(show);
            a_player.DealCard(a_card);
        }
    }
}