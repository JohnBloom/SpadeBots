using System;
using System.Collections.Generic;

namespace Spades
{
    public class Hand
    {
        internal List<Trick> Tricks;

        public int TeamOneTrickCount { get; internal set; }
        public int TeamTwoTrickCount { get; internal set; }

        public Bid Bid { get; internal set; }

        public Hand()
        {
            Tricks = new List<Trick>();
        }

        public void AddTrick(Trick trick)
        {
            if (Tricks.Count == 13)
            {
                throw new Exception("Then hand is over why are there still tricks?");
            }


            //TODO: Figure out who won the hand and increment the trick count
            Tricks.Add(trick);
        }
    }
}
