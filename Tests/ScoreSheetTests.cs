using NUnit.Framework;
using Spades;

namespace Tests
{
    [TestFixture]
    public class ScoreSheetTests
    {
        [Test]
        public void ScoreHandTest()
        {
            var hand = new Hand();
            hand.Bid = new Bid() {PlayerFourBid = 1, PlayerOneBid = 7, PlayerTwoBid = 6, PlayerThreeBid = 2};
            hand.TeamOneTrickCount = 9;
            hand.TeamTwoTrickCount = 4;

            var score = new ScoreSheet();
            score.ScoreHand(hand);
            Assert.AreEqual(90, score.TeamOnePoints);
            Assert.AreEqual(-70, score.TeamTwoPoints);
            Assert.AreEqual(0, score.TeamOneBags);
            Assert.AreEqual(0, score.TeamTwoBags);
        }

        [Test]
        public void ScoreHandWithBagsTest()
        {
            var hand = new Hand();
            hand.Bid = new Bid() { PlayerFourBid = 3, PlayerOneBid = 3, PlayerTwoBid = 3, PlayerThreeBid = 3 };
            hand.TeamOneTrickCount = 9;
            hand.TeamTwoTrickCount = 4;

            var score = new ScoreSheet();
            score.ScoreHand(hand);
            Assert.AreEqual(60, score.TeamOnePoints);
            Assert.AreEqual(-60, score.TeamTwoPoints);
            Assert.AreEqual(3, score.TeamOneBags);
            Assert.AreEqual(0, score.TeamTwoBags);
        }

        [Test]
        public void ScoreHandBagOutTest()
        {
            var hand = new Hand();
            hand.Bid = new Bid() { PlayerFourBid = 3, PlayerOneBid = 3, PlayerTwoBid = 3, PlayerThreeBid = 3 };
            hand.TeamOneTrickCount = 9;
            hand.TeamTwoTrickCount = 4;

            var score = new ScoreSheet();
            score.TeamOneBags = 9;

            score.ScoreHand(hand);
            

            Assert.AreEqual(-40, score.TeamOnePoints);
            Assert.AreEqual(0, score.TeamOneBags);
            
        }
    }
}
