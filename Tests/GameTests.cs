using NUnit.Framework;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class GameTests
    {
        [Test]
        public void MakeTeamsTest()
        {
            var game = new Game();
            game.MakeTeams();
        }

        [Test]
        public void PlayHandTest()
        {
            var game = new Game();
            game.MakeTeams();
            game.PlayHands();
        }


    }
}
