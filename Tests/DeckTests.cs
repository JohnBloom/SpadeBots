using NUnit.Framework;
using PlayingCardsCore;

namespace Tests
{
    [TestFixture] 
    public class DeckTests
    {
        [Test]
        public void CreateDeckTest()
        {
            var deck = new Deck();

            Assert.IsNotNull(deck);
            Assert.AreEqual(52, deck.Cards.Count);
        }

        [Test]
        public void SuffleTest()
        {
            var deck = new Deck();
            deck.Shuffle();

            Assert.AreEqual(52, deck.Cards.Count);
        }
    }
}
