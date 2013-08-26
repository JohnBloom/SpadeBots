using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace Spades
{
    public class Hand
    {
        private Deck _deck;

        internal List<Trick> Tricks;

        public List<IPlayer> Players { get; internal set; }
        

        public bool SpadesHaveBeenBroken { get; internal set; }
        public int TeamOneTrickCount { get; internal set; }
        public int TeamTwoTrickCount { get; internal set; }

        public Bid Bid { get; internal set; }

        public Hand(List<IPlayer> players, Deck deck)
        {
            _deck = deck;
            
            Players = players;

            SpadesHaveBeenBroken = false;
            Tricks = new List<Trick>();
        }

        public void PlayHand()
        {
            //Shuffle the deck
            _deck.Shuffle();
            
            //Get the bids
            GetBids();

            //Play 13 tricks
            PlayTricks();
        }

        public void PlayTricks()
        {
            for (int i = 0; i < 13; i++)
            {
                //TODO The lead should change here based off of the person who took the trick
                var trick = new Trick(this);

                trick.PlayTrick();

                AddTrick(trick);
            }
        }

        public void GetBids()
        {
            var info = new Bid();

            foreach (var player in Players)
            {
                var bid = player.Bid(info);

                if (player.Order == 1) info.PlayerOneBid = bid;
                if (player.Order == 2) info.PlayerTwoBid = bid;
                if (player.Order == 3) info.PlayerThreeBid = bid;
                if (player.Order == 4) info.PlayerFourBid = bid;
            }

            Bid =  info;
        }

        public void AddTrick(Trick trick)
        {
            if (Tricks.Count == 13)
            {
                throw new Exception("Then hand is over why are there still tricks?");
            }

            if(trick.PlayedCards.Any(x=> x.Value.Suit == Suit.Spades))
            {
                SpadesHaveBeenBroken = true;
            }

            //TODO: Figure out who won the hand and increment the trick count
            Tricks.Add(trick);
        }

        public void Deal()
        {
            if (Players == null)
            {
                throw new Exception("You are dealing in a game where there are no players");
            }

            _deck.Shuffle();

            for (int p = 0; p < 4; p++)
            {
                var player = Players[p];

                var cards = new List<Card>();

                for (int i = 0; i < 13; i++)
                {
                    var card = _deck.GetTopCard();
                    cards.Add(card);
                }

                player.ReceiveCards(cards);
            }
        }
    }
}
