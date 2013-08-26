using NUnit.Framework;
using PlayingCards;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class TrickTests
    {
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public IPlayer PlayerThree { get; set; }
        public IPlayer PlayerFour { get; set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            PlayerOne = new DefaultPlayer(1);
            PlayerTwo = new DefaultPlayer(2);
            PlayerThree = new DefaultPlayer(3);
            PlayerFour = new DefaultPlayer(4);
        }

        [Test]
        public void AceOfSpadesWinsTrickTest()
        {
            var trick = new Trick(new Hand());
            
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.King, Suit = Suit.Spades });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Queen, Suit = Suit.Spades });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Jack, Suit = Suit.Spades });
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Ace, Suit = Suit.Spades });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerOne, winner);
        }

        [Test]
        public void TwoOfSpadesWinsTrickTest()
        {
            var trick = new Trick(new Hand());
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Seven, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.Ten, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Two, Suit = Suit.Spades });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Nine, Suit = Suit.Diamonds });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerOne, winner);
        }
    }
}
