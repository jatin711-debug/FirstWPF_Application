using System;
using System.Collections.Generic;
using System.Text;

namespace MTJatinMahajan
{
    class TeamBaseBall : Player
    {
        public int Runs { get; set; }
        public int HomeRuns { get; set; }

        public TeamBaseBall(int id, string name, string type, string team, int games, int homeRuns, int runs) : base(id, name, type, team, games)
        {
            this.PlayerName = name;
            this.TeamName = team;
            this.PlayerId = id;
            this.GamesPlayed = games;
            this.PlayerType = type;
            this.Runs = runs;
            this.HomeRuns = homeRuns;
        }

        public override String ToString()
        {
            return $" {PlayerId} \t {PlayerName} {TeamName} {GamesPlayed} {Runs} {HomeRuns} {GetPoints()} ";
        }

        public override int GetPoints()
        {
            return (int)((Runs - HomeRuns) + (2 * HomeRuns));
        }
    }
}
