namespace Spades
{
    public class ScoreSheet
    {
        public int TeamOnePoints { get; internal set; }
        public int TeamTwoPoints { get; internal set; }
        
        public int TeamOneBags { get; internal set; }
        public int TeamTwoBags { get; internal set; }
         
        internal void Clear()
        {
            TeamOneBags = 0;
            TeamOnePoints = 0;
            TeamTwoBags = 0;
            TeamTwoPoints = 0;
        }

        public void ScoreHand(Hand hand)
        {
            //TODO: Lots of duplication in this. Try to reduce
            var teamOnePointsFromHand = hand.Bid.TeamOneTotalBid >=10 ? 200 : (10*hand.Bid.TeamOneTotalBid);
            var teamTwoPointsFromHand = hand.Bid.TeamTwoTotalBid >= 10 ? 200 : (10 * hand.Bid.TeamTwoTotalBid);

            if (hand.Bid.TeamOneTotalBid > hand.TeamOneTrickCount)
            {
                TeamOnePoints -= teamOnePointsFromHand;
            }
            else
            {
                TeamOnePoints += teamOnePointsFromHand;
                TeamOneBags += (hand.TeamOneTrickCount - hand.Bid.TeamOneTotalBid);
            }

            if (hand.Bid.TeamTwoTotalBid > hand.TeamTwoTrickCount)
            {
                TeamTwoPoints -= teamTwoPointsFromHand;
            }
            else
            {
                TeamTwoPoints += teamTwoPointsFromHand;
                TeamTwoBags += (hand.TeamTwoTrickCount - hand.Bid.TeamTwoTotalBid);
            }

            if(TeamOneBags >= 10)
            {
                TeamOnePoints -= 100;
                TeamOneBags = 0;
            }

            if(TeamTwoBags >= 10)
            {
                TeamTwoPoints -= 100;
                TeamTwoBags = 0;
            }
        }

        public bool HasWinner()
        {
            return (TeamOnePoints >= 500 || TeamTwoPoints >= 500) && (TeamOnePoints != TeamTwoPoints);
        }
    }
}
