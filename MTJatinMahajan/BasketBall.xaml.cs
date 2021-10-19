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
    /// <summary>
    /// Interaction logic for BasketBall.xaml
    /// </summary>
    public partial class BasketBall : Window
    {
        List<TeamBasketBall> basketList = new List<TeamBasketBall>()
        {
            new TeamBasketBall(0,"Jatin","BassketBall","India",1,2,4),
            new TeamBasketBall(1,"Shreya","BassketBall","Pakistan",45,34,35),
            new TeamBasketBall(2,"Mohit","BassketBall","Kathgarh",1,2,45),
            new TeamBasketBall(3,"Akash","BassketBall","Jammu",1,2,3),
            new TeamBasketBall(4,"Johhny","BassketBall","Xora",1,2,32),
        };

        public BasketBall()
        {
            InitializeComponent();
            RefreshListBox();
        }

        private void RefreshListBox()
        {
            var players = from player in basketList
                           select player.PlayerName;

            basketListBox.ItemsSource = players;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int lastId = basketList.Count > 0 ? basketList[basketList.Count - 1].PlayerId : 0;
            TeamBasketBall team = new TeamBasketBall(++lastId, txtName.Text, "Hockey", teamTextBox.Text, int.Parse(matchTextBox.Text), int.Parse(threePointerTextBox.Text), int.Parse(goalsTextBox.Text));
            basketList.Add(team);
            RefreshListBox();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in basketList
                                  where data.PlayerId == basketListBox.SelectedIndex
                                  select data).FirstOrDefault();

            if (selectedPlayer != null)
            {
                selectedPlayer.PlayerName = txtName.Text;
                selectedPlayer.TeamName = teamTextBox.Text;
                selectedPlayer.FieldGoals = int.Parse(goalsTextBox.Text);
                selectedPlayer.ThreePointer = int.Parse(threePointerTextBox.Text);
                selectedPlayer.GamesPlayed = int.Parse(matchTextBox.Text);
            }

            RefreshListBox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedPlayer = (from data in basketList
                                  where data.PlayerId == basketListBox.SelectedIndex
                                  select data).FirstOrDefault();

            basketList.Remove(selectedPlayer);

            // fix ID after deletion
            for (int i = 0; i < basketList.Count; i++)
                basketList[i].PlayerId = i;

            RefreshListBox();
        }

        private void basketListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = basketListBox.SelectedIndex;
            var selectedPlayer = (from data in basketList
                                  where data.PlayerId == index
                                  select data).FirstOrDefault();

            ShowDialog();

            if (selectedPlayer != null)
            {
                txtName.Text = selectedPlayer.PlayerName;
                teamTextBox.Text = selectedPlayer.TeamName;
                goalsTextBox.Text = selectedPlayer.FieldGoals.ToString();
                threePointerTextBox.Text = selectedPlayer.ThreePointer.ToString();
                matchTextBox.Text = selectedPlayer.GamesPlayed.ToString();
            }
        }
    }
}
