using System;
using System.Collections.Generic;
using System.Text;

namespace MTJatinMahajan
{
    class TeamBasketBall:Player
    {
        public int FieldGoals { get; set; }
        public int ThreePointer { get; set; }

        public TeamBasketBall(int id, string name, string type, string team, int games, int threePointer, int goals) : base(id, name, type, team, games)
        {
            this.PlayerName = name;
            this.TeamName = team;
            this.PlayerId = id;
            this.GamesPlayed = games;
            this.PlayerType = type;
            this.FieldGoals = goals;
            this.ThreePointer = threePointer;
        }


        public override String ToString()
        {
            return $" {PlayerId} \t {PlayerName} {TeamName} {GamesPlayed} {FieldGoals} {ThreePointer} {GetPoints()} ";
        }

        public override int GetPoints()
        {
            return (int)((FieldGoals - ThreePointer) + (2 * ThreePointer));
        }
    }
}
