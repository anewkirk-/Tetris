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


        public void UpdateScores()
        {
            List<Score> topScores = sm.GetAll();

            for (int i = 0; i < topScores.Count; i++)
            {
                Score score = topScores[i];

                SM_grid.RowDefinitions.Add(new RowDefinition());

                Border border1 = new Border();
                border1.BorderBrush = new SolidColorBrush(Colors.Black);
                border1.BorderThickness = new Thickness(0,1,1,1);
                Grid.SetColumn(border1, 0);
                Grid.SetRow(border1, i + 1);

                Border border2 = new Border();
                border2.BorderBrush = new SolidColorBrush(Colors.Black);
                border2.BorderThickness = new Thickness(1);
                Grid.SetColumn(border2, 1);
                Grid.SetRow(border2, i + 1);

                Rectangle rect1 = new Rectangle();
                if (i % 2 != 0)
                {
                    rect1.Style = (Style)Application.Current.FindResource("GridRow1");
                }


                Rectangle rect2 = new Rectangle();
                if (i % 2 != 0)
                {
                    rect2.Style = (Style)Application.Current.FindResource("GridRow1");
                }
                Grid.SetColumn(rect2, 1);
                Grid.SetRow(rect2, i + 1);


                Label username = new Label();
                username.Content = score.Username;
                username.Style = Application.Current.FindResource("Scores") as Style;
                username.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Right;
                Grid.SetColumn(username, 0);
                Grid.SetRow(username, i+1);
                
                Label theirScore = new Label();
                theirScore.Content = score.ScoreValue;
                theirScore.Style = Application.Current.FindResource("Scores") as Style;
                theirScore.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Left;
                Grid.SetColumn(theirScore, 1);
                Grid.SetRow(theirScore, i + 1);

                border1.Child = rect1;
                border2.Child = rect2;
                SM_grid.Children.Add(border1);
                SM_grid.Children.Add(border2);
                SM_grid.Children.Add(username);
                SM_grid.Children.Add(theirScore);
            }
        }
    }
}