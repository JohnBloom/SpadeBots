using System.Collections.Generic;
using NUnit.Framework;
using PlayingCards;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class HandTests
    {
        public List<IPlayer> Players { get; set; }
        public Deck Deck { get; set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            Players = new List<IPlayer>();

            Players.Add(new DefaultPlayer(1));
            Players.Add(new DefaultPlayer(2));
            Players.Add(new DefaultPlayer(3));
            Players.Add(new DefaultPlayer(4));

            Deck = new Deck();
        }

        [Test]
        public void CreateHandTest()
        {
            var hand = new Hand(Players, Deck);
            Assert.IsNotNull(hand);
        }
    }
}
