namespace Spades
{
    public class Team
    {
        public PlayerMetadata PlayerOne { get; internal set; }

        public PlayerMetadata PlayerTwo { get; internal set; }

        public Team(PlayerMetadata playerOne, PlayerMetadata playerTwo)
        {
            PlayerOne = playerOne;
            PlayerTwo = PlayerTwo;
        }

    }
}
