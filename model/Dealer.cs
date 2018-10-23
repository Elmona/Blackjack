﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;

        private rules.IWhoWinGameEqualValueStrategy m_winRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWhoWinEqualRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                NotifyCardDrawn();

                return m_newGameRule.NewGame(m_deck, this, a_player);
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            else if (CalcScore() > a_player.CalcScore())
            {
                return true;
            }
            else if (CalcScore() == a_player.CalcScore())
            {
                return m_winRule.IsWinner(this.CalcScore(), a_player.CalcScore());
            }
            return false;

        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                // TODO: Can we add the pause here to?
                // NotifyCardDrawn();
                ShowHand(); 
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null)
            {
                this.ShowHand();

                while (m_hitRule.DoHit(this))
                {
                    BlackJack.model.Card c = m_deck.GetCard();
                    c.Show(true);
                    DealCard(c);
                }
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
