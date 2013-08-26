namespace Spades
{
    public class ScoreSheet
    {
        private int _teamOnePoints;
        private int _teamTwoPoints;
        private int _teamOneBags;
        private int _teamTwoBags;

        public int TeamOnePoints { get { return _teamOnePoints; } }
        public int TeamTwoPoints { get { return _teamTwoPoints; } }

        public int TeamOneBags { get { return _teamOneBags; } }
        public int TeamTwoBags { get { return _teamTwoBags; } }

        internal void Clear()
        {
            _teamOneBags = 0;
            _teamOnePoints = 0;
            _teamTwoBags = 0;
            _teamTwoPoints = 0;
        }

        public void ScoreHand(Hand hand)
        {
            //TODO: Lots of duplication in this. Try to reduce
            var teamOnePointsFromHand = (10*hand.BidInfo.TeamOneTotalBid);
            var teamTwoPointsFromHand = (10 * hand.BidInfo.TeamTwoTotalBid);

            if (hand.BidInfo.TeamOneTotalBid < hand.TeamOneTrickCount)
            {
                _teamOnePoints -= teamOnePointsFromHand;
            }
            else
            {
                _teamOnePoints += teamOnePointsFromHand;
                _teamOneBags += hand.BidInfo.TeamOneTotalBid - hand.TeamOneTrickCount;
            }

            if (hand.BidInfo.TeamTwoTotalBid < hand.TeamTwoTrickCount)
            {
                _teamTwoPoints -= teamTwoPointsFromHand;
            }
            else
            {
                _teamTwoPoints += teamTwoPointsFromHand;
                _teamTwoBags += hand.BidInfo.TeamTwoTotalBid - hand.TeamTwoTrickCount;
            }

            if(_teamOneBags >= 10)
            {
                _teamOnePoints -= 100;
                _teamOneBags = 0;
            }

            if(_teamTwoBags >= 10)
            {
                _teamTwoPoints -= 100;
                _teamTwoBags = 0;
            }
        }

        public bool HasWinner()
        {
            return _teamOnePoints > 500 || _teamTwoPoints > 500;
        }
    }
}
