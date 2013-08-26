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
        public void DealTest()
        {
            var game = new Game();
            game.MakeTeams();
            game.Deal();
        }

        [Test]
        [ExpectedException]
        public void DealNoTeamsPresentTest()
        {
            var game = new Game();
            game.Deal();
        }

        [Test]
        public void GetBidsTest()
        {
            var game = new Game();
            game.MakeTeams();
            game.Deal();
            game.GetBids();
        }

        [Test]
        public void PlayHandTest()
        {
            var game = new Game();
            game.MakeTeams();
            game.PlayHand();
        }


    }
}
