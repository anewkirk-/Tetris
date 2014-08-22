using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tetris.Controllers;
using Tetris.Models;

namespace Tetris.Views.GameScreens
{
    /// <summary>
    /// Interaction logic for ScoresMenu.xaml
    /// </summary>
    public partial class ScoresMenu : UserControl
    {

        private ScoreManager sm = new ScoreManager();

        public ScoresMenu()
        {
            InitializeComponent();
            UpdateScores();
        }

        //private void SM_grid_AutoGeneratingColumn_1(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    if (e.Column.Header.ToString() == "ScoreValue")
        //    {
        //        e.Column.Header = "Score";
        //    }
        //    e.Column.Width = 387;
        //}

        public void UpdateScores()
        {
            List<Score> topScores = sm.GetAll();
            SM_grid.Rows = topScores.Count + 1;

            foreach (Score score in topScores)
            {
                Label username = new Label();
                username.Content = score.Username;
                username.Style = Application.Current.FindResource("Scores") as Style;
                Label theirScore = new Label();
                theirScore.Content = score.ScoreValue;
                theirScore.Style = Application.Current.FindResource("Scores") as Style;

                SM_grid.Children.Add(username);
                SM_grid.Children.Add(theirScore);
            }
        }
    }
}
