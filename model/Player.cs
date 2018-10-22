using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Player
    {
        private List<Card> m_hand = new List<Card>();
        private List<model.ICardDrawnObserver> m_subsribers;

        public Player()
        {
            m_subsribers = new List<model.ICardDrawnObserver>();
        }

        public void DealCard(Card a_card)
        {
            System.Threading.Thread.Sleep(1000);
            m_hand.Add(a_card);
            NotifyCardDrawn();
        }

        public IEnumerable<Card> GetHand()
        {
            return m_hand.Cast<Card>();
        }

        public void ClearHand()
        {
            m_hand.Clear();
        }

        public void ShowHand()
        {
            foreach (Card c in GetHand())
            {
                c.Show(true);
            }
        }

        public int CalcScore()
        {
            int[] cardScores = new int[(int)model.Card.Value.Count]
                {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
            int score = 0;

            foreach(Card c in GetHand()) {
                if (c.GetValue() != Card.Value.Hidden)
                {
                    score += cardScores[(int)c.GetValue()];
                }
            }

            if (score > 21)
            {
                foreach (Card c in GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace && score > 21)
                    {
                        score -= 10;
                    }
                }
            }

            return score;
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
    }
}
