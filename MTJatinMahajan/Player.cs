using System;
using System.Collections.Generic;
using System.Text;

namespace MTJatinMahajan
{
    abstract class Player

    {        
        public string PlayerType { get; set; }
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
        public string TeamName { get; set; }
        public int GamesPlayed { get; set; }


        protected Player(int id,string name,string type, string team, int games)
        {
            this.PlayerId = id;
            this.PlayerName = name;
            this.TeamName = team;
            this.GamesPlayed = games;
            this.PlayerType = type;
        }

        public abstract override string ToString();
        public abstract int GetPoints();
    }
}
