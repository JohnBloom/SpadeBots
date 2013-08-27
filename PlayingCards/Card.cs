using System;

namespace PlayingCards
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }

        internal Guid Identifier;

        public Card()
        {
            Identifier = Guid.NewGuid();
        }
    }
}
