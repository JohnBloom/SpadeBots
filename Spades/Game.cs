using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace Spades
{
    public class Game
    {
        private List<IPlayer> _players;
        private Team _teamOne;
        private Team _teamTwo;
        private List<Hand> _hands;
        private IPlayer _dealer;

        public ScoreSheet ScoreSheet { get; set; }
        public Deck Deck { get; set; }
        public IPlayer PlayerOne { get; set; }
        public IPlayer PlayerTwo { get; set; }
        public IPlayer PlayerThree { get; set; }
        public IPlayer PlayerFour { get; set; }

        

        public Game()
        {
            Deck = new Deck();
            ScoreSheet = new ScoreSheet();
        }

        public void PlayGame()
        {
            MakeTeams();
            PlayHand();

            while(CheckForWinner() == false)
            {
                PlayHand();
            }
        }

        public void MakeTeams()
        {
            GetPlayers();

            _teamOne = new Team(PlayerOne, PlayerThree);
            _teamTwo = new Team(PlayerTwo, PlayerFour);
        }

        private void GetPlayers()
        {
            _players = new List<IPlayer>();
            _hands = new List<Hand>();

            //TODO Use MEF to grab the different instances of players
            //TODO Dont use Order to determine who is who. This can be mishandled or changed by the player
            PlayerOne = new DefaultPlayer(1);
            PlayerTwo = new DefaultPlayer(2);
            PlayerThree = new DefaultPlayer(3);
            PlayerFour = new DefaultPlayer(4);

            _players.Add(PlayerOne);
            _players.Add(PlayerTwo);
            _players.Add(PlayerThree);
            _players.Add(PlayerFour);

            _dealer = PlayerOne;
        }


        public void Deal()
        {
            if(_players == null)
            {
                throw new Exception("You are dealing in a game where there are no players");
            }


            Deck.Shuffle();

            for (int p = 0; p < 4; p++)
            {
                var player = _players[p];

                var cards = new List<Card>();

                for (int i = 0; i < 13; i++)
                {                    
                    var card = Deck.GetTopCard();
                    cards.Add(card); 
                }

                player.ReceiveCards(cards);
            }
        }

        public void PlayHand()
        {
            ChangeDealer();

            Deal();

            Deck.Shuffle();

            var hand = new Hand();

            hand.BidInfo = GetBids();

            for (int i = 0; i < 13; i++)
            {
                //TODO The lead should change here based off of the person who took the trick
                var trick = PlayTrick(hand);
                hand.AddTrick(trick);
            }

            _hands.Add(hand);

            RecordScores(hand);
        }

        public void ChangeDealer()
        {
            //Moves the first player to the end and sets the new first player as dealer.
            var firstPlayer = _players[0];
            _players.RemoveAt(0);
            _players.Add(firstPlayer);

            _dealer = _players.First();
        }

        public Bid GetBids()
        {
            var info = new Bid();

            foreach (var player in _players)
            {
                var bid = player.Bid(info);

                if (player.Order == 1) info.PlayerOneBid = bid;
                if (player.Order == 2) info.PlayerTwoBid = bid;
                if (player.Order == 3) info.PlayerThreeBid = bid;
                if (player.Order == 4) info.PlayerFourBid = bid;
            }

            return info;
        }

        public Trick PlayTrick(Hand hand)
        {
            var trick = new Trick(hand);

            foreach (var player in _players)
            {
                player.PlayCard(trick);
            }

            return trick;
        }

        public void RecordScores(Hand hand)
        {
            ScoreSheet.ScoreHand(hand);
        }

        public bool CheckForWinner()
        {
            var hasWinner = ScoreSheet.HasWinner();
            return hasWinner;
        }
    }
}
