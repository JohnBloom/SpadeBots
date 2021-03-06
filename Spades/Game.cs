﻿using System;
using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace Spades
{
    public class Game
    {
        private List<PlayerMetadata> _players;
        private Team _teamOne;
        private Team _teamTwo;
        private List<Hand> _hands;
        private PlayerMetadata _dealer;

        public ScoreSheet ScoreSheet { get; set; }
        public Deck Deck { get; set; }

        public PlayerMetadata PlayerOne { get; set; }
        public PlayerMetadata PlayerTwo { get; set; }
        public PlayerMetadata PlayerThree { get; set; }
        public PlayerMetadata PlayerFour { get; set; }

        public Game()
        {
            Deck = new Deck();
            ScoreSheet = new ScoreSheet();
        }

        public void PlayGame()
        {
            //Make up the teams
            MakeTeams();

            //Play hands
            PlayHands();
        }

        public void MakeTeams()
        {
            GetPlayers();

            _teamOne = new Team(PlayerOne, PlayerThree);
            _teamTwo = new Team(PlayerTwo, PlayerFour);
        }

        private void GetPlayers()
        {
            _players = new List<PlayerMetadata>();
            _hands = new List<Hand>();

            //TODO Use MEF to grab the different instances of players
            PlayerOne = new PlayerMetadata(1, new DefaultPlayer());
            PlayerTwo = new PlayerMetadata(2, new DefaultPlayer());
            PlayerThree = new PlayerMetadata(3, new DefaultPlayer());
            PlayerFour = new PlayerMetadata(4, new DefaultPlayer());

            _players.Add(PlayerOne);
            _players.Add(PlayerTwo);
            _players.Add(PlayerThree);
            _players.Add(PlayerFour);

            _dealer = PlayerOne;
        }

        public void PlayHands()
        {
            while(CheckForWinner() == false)
            {
                ChangeDealer();

                var hand = new Hand(_players, Deck);

                _hands.Add(hand);

                RecordScores(hand);
            }
        }

        public void ChangeDealer()
        {
            //Moves the first player to the end and sets the new first player as dealer.
            var firstPlayer = _players[0];
            _players.RemoveAt(0);
            _players.Add(firstPlayer);

            _dealer = _players.First();
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
