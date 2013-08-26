using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace Spades
{
    public class Trick
    {
        private Hand _hand;

        public Suit LeadSuit { get; internal set; }
        public Dictionary<IPlayer, Card> PlayedCards { get; internal set; }

        public Trick(Hand hand)
        {
            _hand = hand;
            PlayedCards = new Dictionary<IPlayer, Card>();
        }

        internal void PlayCard(IPlayer player, Card card)
        {
            if(IsCardPlayable(card) == false)
            {
                throw new Exception(player.PlayerName + " is Cheating and playing cards that are not playable!");
            }

            if (PlayedCards.Any() == false)
            {
                LeadSuit = card.Suit;
            }

            PlayedCards.Add(player, card);
        }

        public bool IsCardPlayable(Card card)
        {
            //TODO: Implement playable logic
            return true;
        }

        public IPlayer GetWinningPlayer()
        {
            if (PlayedCards.Count != 4)
            {
                return null;
            }

            var orderedList = PlayedCards.OrderByDescending(x => x.Value.Suit == Suit.Spades)
                .ThenByDescending(x => x.Value.Suit == LeadSuit)
                .ThenByDescending(x => (int) x.Value.Rank);

            return orderedList.Select(x=> x.Key)
                              .First();
        }
    }
}
