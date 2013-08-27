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
        public Dictionary<PlayerMetadata, Card> PlayedCards { get; internal set; }

        public Trick(Hand hand)
        {
            _hand = hand;
            PlayedCards = new Dictionary<PlayerMetadata, Card>();
        }

        public void PlayTrick()
        {
            foreach (var playerMeta in _hand.Players)
            {
                playerMeta.Player.PlayCard(this);
            }
        }

        internal void PlayCard(PlayerMetadata playerMeta, Card card)
        {
            if (IsCardPlayable(playerMeta, card) == false)
            {
                throw new Exception(playerMeta.Player.PlayerName + " is Cheating and playing cards that are not playable!");
            }

            if (PlayedCards.Any() == false)
            {
                LeadSuit = card.Suit;
            }

            PlayedCards.Add(playerMeta, card);
        }

        public bool IsCardPlayable(PlayerMetadata player, Card card)
        {
            if (card.Suit == Suit.Spades && _hand.SpadesHaveBeenBroken == false) return false; //And the player has a suit other than spades

            return true;
        }

        public PlayerMetadata GetWinningPlayer()
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
