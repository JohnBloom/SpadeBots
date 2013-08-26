namespace Spades
{
    public class Team
    {
        private int _tricksTaken;
        private int _totalBid;

        public int TricksTaken { get { return _tricksTaken; } }

        public int TotalBid { get { return _totalBid; } }

        public Team(IPlayer playerOne, IPlayer playerTwo)
        {
            
        }
    }
}
