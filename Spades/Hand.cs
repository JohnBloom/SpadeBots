using System.Collections.Generic;

namespace Spades
{
    public class Hand
    {
        private List<Trick> _tricks;

        public int TeamOneTrickCount { get; internal set; }
        public int TeamTwoTrickCount { get; internal set; }

        public Bid Bid { get; internal set; }

        

        public Hand()
        {
            _tricks = new List<Trick>();
        }

        public void AddTrick(Trick trick)
        {
            //TODO: Figure out who won the hand and increment the trick count
            _tricks.Add(trick);
        }
    }
}
