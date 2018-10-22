using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        private List<model.ICardDrawnObserver> m_subsribers;

        public Game()
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            m_subsribers = new List<model.ICardDrawnObserver>();
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            bool response = m_dealer.NewGame(m_player);
            NotifyCardDrawn();
            return response;
        }

        public bool Hit()
        {
            bool response = m_dealer.Hit(m_player);
            NotifyCardDrawn();
            return response;
        }

        public bool Stand()
        {
            m_dealer.Stand();
            return true;
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }

        public void AddSubscriber(model.ICardDrawnObserver m_subsriber)
        {
            m_subsribers.Add(m_subsriber);
        }

        public void RemoveSubsriber(model.ICardDrawnObserver m_subsriber)
        {
            m_subsribers.Remove(m_subsriber);
        }

        private void NotifyCardDrawn()
        {
            foreach (var subsriber in m_subsribers)
            {
                subsriber.CardDrawn();
            }
        }

        // public void AddSubscriber(model.ICardDrawnObserver m_subsriber)
        // {
        //     this.m_dealer.AddSubscriber(m_subsriber);
        // }
    }
}
