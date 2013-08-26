using System;
using PlayingCardsCore;

namespace Spades
{
    public class Trick
    {
        private Hand _hand;

        private Card _playerOneCard;
        private Card _playerTwoCard;
        private Card _playerThreeCard;
        private Card _playerFourCard;

        public Card PlayerOneCard { get { return _playerOneCard; } }
        public Card PlayerTwoCard { get { return _playerTwoCard; } }
        public Card PlayerThreeeCard { get { return _playerThreeCard; } }
        public Card PlayerFourCard { get { return _playerFourCard; } }

        public Trick(Hand hand)
        {
            _hand = hand;
        }

        internal void PlayCard(IPlayer player, Card card)
        {
            if(IsCardPlayable(card))
            {
                throw new Exception(player.PlayerName + " is Cheating and playing cards that are not playable!");
            }

            if (player.Order == 1) _playerOneCard = card;
            if (player.Order == 2) _playerTwoCard = card;
            if (player.Order == 3) _playerThreeCard = card;
            if (player.Order == 4) _playerFourCard = card;
        }

        public bool IsCardPlayable(Card card)
        {
            //TODO: Implement playable logic
            return true;
        }
    }
}
