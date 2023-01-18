﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    internal class Goalie : Player
    {
        private double _saveValuePercentage;
        public double GoalsAgainstAverage { get; set; }
        //public double SavePercentage { get; set; }
        public int Shutouts { get; private set; }


        public double SavePercentage
        {
            get => _saveValuePercentage;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("Percentage must be between 0 and 1");
                }
                _saveValuePercentage = value;
            }
        }
        public Goalie(int playerNo, string name) : base (playerNo, name, Position.G)
        {

        }
        public Goalie(int playerNo, string name, int gamesPlayed) : base(playerNo, name, Position.G)
        {
            base.GamesPlayed = gamesPlayed;
        }

        public void AddShutout()
        {
            Shutouts++;
        }
    }
}
