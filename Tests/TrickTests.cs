using System.Collections.Generic;
using NUnit.Framework;
using PlayingCards;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class TrickTests
    {
        public PlayerMetadata PlayerOne { get; set; }
        public PlayerMetadata PlayerTwo { get; set; }
        public PlayerMetadata PlayerThree { get; set; }
        public PlayerMetadata PlayerFour { get; set; }

        public Deck Deck { get; set; }
        public List<PlayerMetadata> Players { get; set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            Players = new List<PlayerMetadata>();

            PlayerOne = new PlayerMetadata(1, new DefaultPlayer());
            PlayerTwo = new PlayerMetadata(2, new DefaultPlayer());
            PlayerThree = new PlayerMetadata(3, new DefaultPlayer());
            PlayerFour = new PlayerMetadata(4, new DefaultPlayer());

            Players.Add(PlayerOne);
            Players.Add(PlayerTwo);
            Players.Add(PlayerThree);
            Players.Add(PlayerFour);
        }

        [Test]
        public void AllTrumpsGetWinningPlayerTest()
        {
            var trick = new Trick(new Hand(Players, Deck) { SpadesHaveBeenBroken = true });
            
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.King, Suit = Suit.Spades });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Queen, Suit = Suit.Spades });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Jack, Suit = Suit.Spades });
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Ace, Suit = Suit.Spades });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerOne, winner);
        }

        [Test]
        public void TrumpInGetWinningPlayerTest()
        {
            var trick = new Trick(new Hand(Players, Deck) { SpadesHaveBeenBroken = true});
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Seven, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.Ten, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Two, Suit = Suit.Spades });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Nine, Suit = Suit.Diamonds });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerThree, winner);
        }

        [Test]
        public void AllSameNonTrumpSuitGetWinningPlayerTest()
        {
            var trick = new Trick(new Hand(Players, Deck) { SpadesHaveBeenBroken = true });
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Seven, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.Ten, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Two, Suit = Suit.Diamonds });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Nine, Suit = Suit.Diamonds });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerTwo, winner);
        }

        [Test]
        public void DifferentSuitsNoTrumpsGetWinningPlayerTest()
        {
            var trick = new Trick(new Hand(Players, Deck) { SpadesHaveBeenBroken = true });
            trick.PlayCard(PlayerOne, new Card() { Rank = Rank.Seven, Suit = Suit.Clubs });
            trick.PlayCard(PlayerTwo, new Card() { Rank = Rank.Ten, Suit = Suit.Hearts });
            trick.PlayCard(PlayerThree, new Card() { Rank = Rank.Two, Suit = Suit.Clubs });
            trick.PlayCard(PlayerFour, new Card() { Rank = Rank.Nine, Suit = Suit.Diamonds });

            var winner = trick.GetWinningPlayer();

            Assert.AreEqual(PlayerOne, winner);
        }
    }
}
