using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MTJatinMahajan
{
    
    public partial class BaseBall : Window
    {

        List<TeamBaseBall> baseList = new List<TeamBaseBall>()
        {
            new TeamBaseBall(0,"Jatin","Base Ball","---",1,2,4),
            new TeamBaseBall(1,"Mago","Base Ball","---",45,34,35),
            new TeamBaseBall(0,"Honey","Base Ball","---",1,2,4),
            new TeamBaseBall(0,"mew","Base Ball","---",1,2,4),
            new TeamBaseBall(0,"Khang","Base Ball","---",1,2,4),
        };
        public BaseBall()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var players = from player in baseList
                          select player.PlayerName;

            baseListBox.ItemsSource = players;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            int lastId = baseList.Count > 0? baseList[baseList.Count - 1].PlayerId: 0;
            TeamBaseBall team = new TeamBaseBall(++lastId, txtName.Text,"BaseBall", teamTextBox.Text, int.Parse(matchTextBox.Text), int.Parse(runs.Text), int.Parse(homeRuns.Text));
            baseList.Add(team);
            RefreshListBox();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in baseList
                                  where data.PlayerId == baseListBox.SelectedIndex
                                  select data).FirstOrDefault();

            if (selectedPlayer != null)
            {
                selectedPlayer.PlayerName = txtName.Text;
                selectedPlayer.TeamName = teamTextBox.Text;
                selectedPlayer.Runs = int.Parse(runs.Text);
                selectedPlayer.HomeRuns = int.Parse(homeRuns.Text);
                selectedPlayer.GamesPlayed = int.Parse(matchTextBox.Text);
            }

            RefreshListBox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in baseList
                                  where data.PlayerId == baseListBox.SelectedIndex
                                  select data).FirstOrDefault();

            baseList.Remove(selectedPlayer);

            // fix ID after deletion
            for (int i = 0; i < baseList.Count; i++)
                baseList[i].PlayerId = i;

            RefreshListBox();
        }

        private void baseListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = baseListBox.SelectedIndex;
            var selectedPlayer = (from data in baseList
                                  where data.PlayerId == index
                                  select data).FirstOrDefault();

            if (selectedPlayer != null)
            {
                txtName.Text = selectedPlayer.PlayerName;
                teamTextBox.Text = selectedPlayer.TeamName;
                runs.Text = selectedPlayer.Runs.ToString();
                homeRuns.Text = selectedPlayer.HomeRuns.ToString();
                matchTextBox.Text = selectedPlayer.GamesPlayed.ToString();
            }
        }
    }
}
