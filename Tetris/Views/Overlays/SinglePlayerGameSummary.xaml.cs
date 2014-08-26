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
    /// Interaction logic for GameSummary.xaml
    /// </summary>
    public partial class SinglePlayerGameSummary : UserControl
    {
        private ScoreManager sm = new ScoreManager();

        public SinglePlayerGameSummary()
        {
            InitializeComponent();
        }

        public void AddScore()
        {
            Score newScore = new Score(AHS_name.Text, int.Parse(SPGS_score.Content.ToString()));
            sm.Submit(newScore);
        }
    }
}
