using System.Collections.Generic;

namespace Spades
{
    public class Hand
    {
        private List<Trick> _tricks;
        private int _teamOneTrickCount;
        private int _teamTwoTrickCount;

        public int TeamOneTrickCount { get { return _teamOneTrickCount; } }
        public int TeamTwoTrickCount { get { return _teamTwoTrickCount; } }

        public Bid BidInfo { get; internal set; }

        

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
