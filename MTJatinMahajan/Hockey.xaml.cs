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
    public partial class Hockey : Window
    {
        List<TeamHockey> hockeyList = new List<TeamHockey>()
        {
            new TeamHockey(0,"Jatin","Hockey","---",1,2,4),
            new TeamHockey(1,"Jason","Hockey","---",45,34,35),
            new TeamHockey(2,"Methew","Hockey","---",1,2,4),
            new TeamHockey(3,"Broy","Hockey","---",1,2,4),
            new TeamHockey(4,"Jatin","Hockey","---",1,2,4),
        };

        private void RefreshListBox()
        {
            var empNames = from player in hockeyList
                           select player.PlayerName;

            hockeyListBox.ItemsSource = empNames;
        }


        public Hockey()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int lastId = hockeyList.Count > 0 ? hockeyList[hockeyList.Count - 1].PlayerId : 0;

            TeamHockey team = new TeamHockey(++lastId,txtName.Text,"Hockey",teamTextBox.Text,int.Parse(matchTextBox.Text), int.Parse(assistTextBox.Text), int.Parse(goalsTextBox.Text));
            hockeyList.Add(team);

            RefreshListBox();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in hockeyList
                               where data.PlayerId == hockeyListBox.SelectedIndex
                               select data).FirstOrDefault();

            if (selectedPlayer != null)
            {
                selectedPlayer.PlayerName = txtName.Text;
                selectedPlayer.TeamName = teamTextBox.Text;
                selectedPlayer.Goals = int.Parse(goalsTextBox.Text);
                selectedPlayer.Assist = int.Parse(assistTextBox.Text);
                selectedPlayer.GamesPlayed = int.Parse(matchTextBox.Text); 
            }

            RefreshListBox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in hockeyList
                               where data.PlayerId == hockeyListBox.SelectedIndex
                               select data).FirstOrDefault();

            hockeyList.Remove(selectedPlayer);

            // fix ID after deletion
            for (int i = 0; i < hockeyList.Count; i++)
                hockeyList[i].PlayerId = i;

            RefreshListBox();
        }

        private void hockeyListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = hockeyListBox.SelectedIndex;

            var selectedPlayer = (from data in hockeyList
                               where data.PlayerId == index
                               select data).FirstOrDefault();

            if (selectedPlayer != null)
            {
                txtName.Text = selectedPlayer.PlayerName;
                teamTextBox.Text = selectedPlayer.TeamName;
                goalsTextBox.Text = selectedPlayer.Goals.ToString();
                assistTextBox.Text = selectedPlayer.Assist.ToString();
                matchTextBox.Text = selectedPlayer.GamesPlayed.ToString();
            }
        }
    }
    }

