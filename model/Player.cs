using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
  class Player
  {
    private List<Card> m_hand = new List<Card>();
    private List<model.ICardDrawnObserver> m_subscribers;

    public Player()
    {
      m_subscribers = new List<model.ICardDrawnObserver>();
    }

    public void DealCard(Card a_card)
    {
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

      foreach (Card c in GetHand())
      {
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

    public void AddSubscriber(model.ICardDrawnObserver m_subscriber)
    {
      m_subscribers.Add(m_subscriber);
    }

    public void RemoveSubsriber(model.ICardDrawnObserver m_subscriber)
    {
      m_subscribers.Remove(m_subscriber);
    }

    public void NotifyCardDrawn()
    {
      foreach (var subscriber in m_subscribers)
      {
        subscriber.CardDrawn();
      }
    }

    public void insertCard(model.Card card)
    {
      card.Show(true);
      this.DealCard(card);
    }

    public void insertCard(model.Card card, bool show)
    {
      card.Show(show);
      this.DealCard(card);
    }
  }
}
