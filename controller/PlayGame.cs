using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model;

namespace BlackJack.controller
{
    class PlayGame : model.ICardDrawnObserver
    {
        private model.Game a_game;
        private view.IView a_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            this.a_game = a_game;
            this.a_view = a_view;

            this.a_game.AddSubscriber(this);
            a_view.DisplayWelcomeMessage();
        }

        public bool Play()
        {
            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
                a_view.DisplayWelcomeMessage();
            }

            var input = a_view.GetInput();

            switch (input)
            {
                case view.Event.Play:
                    a_game.NewGame();
                    break;
                case view.Event.Hit:
                    a_game.Hit();
                    break;
                case view.Event.Stand:
                    a_game.Stand();
                    break;
                case view.Event.Quit:
                    return false;
                case view.Event.None:
                    return true;
            }

            return true;
        }

        public void CardDrawn()
        {
            System.Threading.Thread.Sleep(1000);
            a_view.DisplayWelcomeMessage();
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());
        }
    }
}
