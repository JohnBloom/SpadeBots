using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCards;

namespace Spades
{
    public class DefaultPlayer : IPlayer
    {
        private List<Card> _handOfCards;

        public string PlayerName { get { return "Default Player"; } }

        public Card PlayCard(Trick currentTrick)
        {
            //TODO Implement playing card logic
            return null; //_handOfCards.First(x=> currentTrick.IsCardPlayable(this, x));
        }

        public void ReceiveCards(List<Card> handOfCards)
        {
            _handOfCards = handOfCards;
        }

        public int Bid(Bid bidInfo)
        {
            //TODO Implement Bidding logic
            return 2;
        }
    }
}
