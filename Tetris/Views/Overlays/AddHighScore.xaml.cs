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

namespace Tetris.Views.Overlays
{
    /// <summary>
    /// Interaction logic for AddHighScore.xaml
    /// </summary>
    public partial class AddHighScore : UserControl
    {

        private ScoreManager sm = new ScoreManager();

        public AddHighScore()
        {
            InitializeComponent();
        }

        private void AHS_submit_Click_1(object sender, RoutedEventArgs e)
        {
            Score newScore = new Score(AHS_name.ToString(), int.Parse(AHS_score.ToString()));
            sm.Submit(newScore);
        }

        private void AHS_cancel_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
