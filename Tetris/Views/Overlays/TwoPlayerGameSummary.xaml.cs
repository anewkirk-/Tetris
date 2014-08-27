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
    /// Interaction logic for TwoPlayerGameSummary.xaml
    /// </summary>
    public partial class TwoPlayerGameSummary : UserControl
    {
        private ScoreManager sm = new ScoreManager();

        public TwoPlayerGameSummary()
        {
            InitializeComponent();
        }

        public void PlayerOne_AddScore()
        {
            Score playerOne_newScore = new Score(AHS_playerOne_name.Text, int.Parse(TPGS_playerOne_score.Content.ToString()));
            sm.Submit(playerOne_newScore);
        }

        public void PlayerTwo_AddScore()
        {
            Score playerTwo_newScore = new Score(AHS_playerTwo_name.Text, int.Parse(TPGS_playerTwo_score.Content.ToString()));
            sm.Submit(playerTwo_newScore);
        }
    }
}