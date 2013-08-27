using System.Collections.Generic;
using NUnit.Framework;
using PlayingCards;
using Spades;

namespace Tests
{
    [TestFixture] 
    public class HandTests
    {
        public List<PlayerMetadata> Players { get; set; }
        public Deck Deck { get; set; }

        [TestFixtureSetUp]
        public void Setup()
        {
            Players = new List<PlayerMetadata>();

            Players.Add(new PlayerMetadata(1, new DefaultPlayer()));
            Players.Add(new PlayerMetadata(1, new DefaultPlayer()));
            Players.Add(new PlayerMetadata(1, new DefaultPlayer()));
            Players.Add(new PlayerMetadata(1, new DefaultPlayer()));

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
