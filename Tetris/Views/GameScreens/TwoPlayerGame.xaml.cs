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

namespace Tetris.Views.GameScreens
{
    /// <summary>
    /// Interaction logic for TwoPlayerGame.xaml
    /// </summary>
    public partial class TwoPlayerGame : UserControl
    {

        Game PlayerOneGame;
        Game PlayerTwoGame;

        public TwoPlayerGame()
        {
            InitializeComponent();
        }

        public void NewGame(GameMode type)
        {
            PlayerOneGame = new Game(type);
            PlayerTwoGame = new Game(type);
        }

        public GameMode GetGameMode()
        {
            return PlayerOneGame.Mode;
        }

        public void PauseGame()
        {
            PlayerOneGame.Stop();
            PlayerTwoGame.Stop();
        }

        public void ResumeGame()
        {
            PlayerOneGame.Start();
            PlayerTwoGame.Start();
        }
    }
}