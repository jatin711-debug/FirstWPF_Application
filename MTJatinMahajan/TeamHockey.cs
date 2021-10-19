using System;
using System.Collections.Generic;
using System.Text;

namespace MTJatinMahajan
{
    class TeamHockey : Player
    {
        public int Assist { get; set; }
        public int Goals { get; set; }

        public TeamHockey(int id,string name,string type,string team,int games,int assist,int goals) : base(id,name,type,team,games)
        {
            this.PlayerName = name;
            this.TeamName = team;
            this.PlayerId = id;
            this.GamesPlayed = games;
            this.Assist = assist;
            this.Goals = goals;
            this.PlayerType = type;
        }

        
       public override String ToString()
        {
            return $" {PlayerId} \t {PlayerName} {TeamName} {GamesPlayed} {Assist} {Goals} {GetPoints()} ";
        }

        public override int GetPoints()
        {
            return (int)(Assist + (2 * Goals));
        }
    }
}
