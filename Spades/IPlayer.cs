using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayingCards;

namespace Spades
{
    public interface IPlayer
    {
        string PlayerName { get; }
        int Order { get; }

        Card PlayCard(Trick currentTrick);

        void ReceiveCards(List<Card> handOfCards);

        int Bid(Bid bidInfo);
    }
}
