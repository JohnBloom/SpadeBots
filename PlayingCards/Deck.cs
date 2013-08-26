using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingCards
{
    public class Deck
    {
        private List<Card> _cards;

        public List<Card> Cards { get { return _cards; } }
        public bool DeckIsEmpty { get { return _cards.Any() == false; } }

        public Deck()
        {
            _cards = new List<Card>();

            for (int i = 1; i <= 52; i++)
            {
                var suit = 1;
                var rank = i;

                if(i>13 && i<=26)
                {
                    suit = 2;
                    rank = i - 13;
                }
                else if(i>26 && i<=39)
                {
                    suit = 3;
                    rank = i - 26;
                }
                else if(i > 39)
                {
                    suit = 4;
                    rank = i - 39;
                }

                var card = new Card { Suit = (Suit)(suit), Rank = (Rank)(rank) };
                _cards.Add(card);
            }
        }

        public void Shuffle()
        {
            var ran = new Random((int)DateTime.Now.TimeOfDay.TotalMilliseconds);

            var newDeck = new List<Card>();
            
            for (int i = 51; i >= 0; i--)
            {
                var index = ran.Next(0, i); 
                
                var card = Cards[index];

                _cards.Remove(card);
                
                newDeck.Add(card);    
            }

            _cards = newDeck;
        }

        public Card GetTopCard()
        {
            var card = _cards.First();
            _cards.Remove(card);
            
            return card;
        }
    }
}
