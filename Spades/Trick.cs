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

        public void PlayTrick()
        {
            foreach (var player in _hand.Players)
            {
                player.PlayCard(this);
            }
        }

        internal void PlayCard(IPlayer player, Card card)
        {
            if (IsCardPlayable(player, card) == false)
            {
                throw new Exception(player.PlayerName + " is Cheating and playing cards that are not playable!");
            }

            if (PlayedCards.Any() == false)
            {
                LeadSuit = card.Suit;
            }

            PlayedCards.Add(player, card);
        }

        public bool IsCardPlayable(IPlayer player, Card card)
        {
            if (card.Suit == Suit.Spades && _hand.SpadesHaveBeenBroken == false) return false; //And the player has a suit other than spades

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
