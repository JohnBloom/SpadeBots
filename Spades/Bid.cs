namespace Spades
{
    public class Bid
    {
        public int PlayerOneBid { get; internal set; }
        public int PlayerTwoBid { get; internal set; }
        public int PlayerThreeBid { get; internal set; }
        public int PlayerFourBid { get; internal set; }

        //TODO: Teams are defined in the hand. Try to use those teams rather than hard coding players
        public int TeamOneTotalBid { get { return PlayerOneBid + PlayerThreeBid; } }
        public int TeamTwoTotalBid { get { return PlayerTwoBid + PlayerFourBid; } }
    }
}
