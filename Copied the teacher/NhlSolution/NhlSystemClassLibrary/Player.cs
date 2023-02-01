using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlSystemClassLibrary;

namespace NhlSystemClassLibrary
{
    public class Player
    {
        // TODO: Define properties for:
        const int MinPlayerNum = 1;
        const int MaxPlayerNum = 98;

        private int _playerNum;
        private string _name;
        private int _gamesPlayed;
        private int _goals;
        private int _assists;
        // 1) PlayerNo: int {PlayerNo >= 1 and PlayerNo <= 98}
        public int PlayerNum
        {
            get
            {
                return _playerNum;
            }
            private set
            {
                if (!Utilities.NumInRange(value, MinPlayerNum, MaxPlayerNum))
                {
                    throw new ArgumentException("Number must be positive");
                }
                _playerNum = value;
            }
        }
        // 2) Name: string {cannot be blank}
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(value), "Cannot be blank");
                }
            }
        }
        // 3) Position: Position
        public Position Position { get; private set; }
        // 4) GamesPlayed: int {GamesPlayed >= 0}
        public int GamesPlayed
           { 
            get => _gamesPlayed;
            set
            {
                if (!Utilities.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException(nameof(value), "GamesPlayed must be a positive or Zero number");
                }
            }
        
        
        }
        // 5) Goals: int {Goals >= 0}
        public int Goals
        {
            get => _goals;
            set
            {
                if (!Utilities.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException("Goals must be positive or zero");
                }
            }
        }
        // 6) Assists: int {Assists >= 0}
        public int Assists
        {
            get => _assists;
            set
            {
                if (!Utilities.NumInRange(value, 0, int.MaxValue))
                {
                    throw new ArgumentException("Goals must be positive or zero");
                }
            }
        }
        // 7) Points : int { Goals + Assists}
        public int Points => Goals + Assists;

        // TODO: Define constructor with parameters for:
        // PlayerNo, Name, Positiion, GamesPlayed, Goals, Assists

        public static Player Parse(string csvLine)
        {
            const char Delimiter = ',';
            /*
             * The Order of the Column value are (as defined in the ToString() methos:
             * PlayerNo  0
             * Name   1
             * Position        2
             * GamesPlayed       3
             * Goals         4
             * Assists        5
             */

            const int ExpectedColumnCount = 6;
            string[] tokens = csvLine.ReplaceLineEndings().Split(Delimiter);
            //Verify length of the array
            if (tokens.Length != ExpectedColumnCount)
            {
                throw new FormatException($"CSV line must contain exactly {ExpectedColumnCount} values");
            }
            int playerNo = int.Parse(tokens[0]);
            string name = tokens[1];
            Position position = Enum.Parse<Position>(tokens[2]);
            //Psition position
            int gamesPlayed = int.Parse(tokens[3]);
            int goals = int.Parse(tokens[4]);
            int assists = int.Parse(tokens[5]);
            return new Player(playerNo, name, position, gamesPlayed, goals, assists);
        }

        public static bool TryParse(string csvLine, Player currentPlayer)
        {
            bool success = false;

            try
            {
                currentPlayer = Parse(csvLine);
                success = true;
            }
            catch(FormatException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new Exception($"Player TryParse method failed with exception {ex.Message}");
            }

            return success;
        }


        // TODO: Define methods to
        // 1) add 1 to GamesPlayed
        // 2) add 1 to Goals
        // 3) add 1 to Assists
        public void AddGamesPlayed()
        {
            GamesPlayed +=1;
        }
        public void AddGoals()
        {
            Goals ++;
        }
        public void AddAssist()
        {
            Assists ++;
        }



        public Player(int playerNum, string name, Position position)
        {
            PlayerNum = _playerNum;
            Name = _name;
            Position = position;
        }

        public Player(int playerNum, string name, Position position, int gamesPlayed, int goals, int assists)        {
            PlayerNum = _playerNum;
            Name = _name;
            GamesPlayed = _gamesPlayed;
            Goals = _goals;
            Assists = _assists;
            Position = position;
        }

    }
}
