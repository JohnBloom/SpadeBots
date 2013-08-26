using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCardsCore;

namespace Spades
{
    public class DefaultPlayer : IPlayer
    {
        private readonly int _order;

        private List<Card> _handOfCards;

        public int Order { get { return _order; } }

        public DefaultPlayer(int order)
        {
            _order = order;
        }

        public string PlayerName { get { return "Default Player"; } }

        public Card PlayCard(Trick currentTrick)
        {
            //TODO Implement playing card logic
            return _handOfCards.First(currentTrick.IsCardPlayable);
        }

        public void ReceiveCards(List<Card> handOfCards)
        {
            _handOfCards = handOfCards;
        }

        public int Bid(BidInfo bidInfo)
        {
            //TODO Implement Bidding logic
            return 2;
        }
    }
}
