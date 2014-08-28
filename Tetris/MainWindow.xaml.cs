using Microsoft.Win32;
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
using Tetris.Views.GameScreens;
using Tetris.Views.Overlays;
using Tetris.Controllers;
using System.Timers;
using System.Threading;
using System.Windows.Threading;
using Tetris.Models;
using System.Media;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
         * Is all of this supposed to be default visibility?
         * -a
         */

        //Instantiate
        MainMenu mainMenu = new MainMenu();

        //Menus
        SinglePlayerModeSelect SP_modeSelect = new SinglePlayerModeSelect();
        TwoPlayerModeSelect TP_modeSelect = new TwoPlayerModeSelect();
        ScoresMenu scoreMenu = new ScoresMenu();

        //Games
        SinglePlayerGame SP_gameView = new SinglePlayerGame();
        TwoPlayerGame TP_gameView = new TwoPlayerGame();

        //Overlays
        PauseScreen pause = new PauseScreen();
        QuitConfirm quit = new QuitConfirm();
        SinglePlayerGameSummary SP_gameSummary = new SinglePlayerGameSummary();
        TwoPlayerGameSummary TP_gameSummary = new TwoPlayerGameSummary();

        //Other
        SaveFileDialog saveDialog = new SaveFileDialog();
        private ScoreManager csm;

        //Overlay Canvas Background
        Canvas backCanvas = new Canvas();
        Canvas backCanvas2 = new Canvas();

        //Keys
        public Key P1Left { get; set; }
        public Key P1Right { get; set; }
        public Key P1Down { get; set; }
        public Key P1Drop { get; set; }
        public Key P1Rotate { get; set; }
        public Key P2Left { get; set; }
        public Key P2Right { get; set; }
        public Key P2Down { get; set; }
        public Key P2Drop { get; set; }
        public Key P2Rotate { get; set; }
        public Key PauseKey { get; set; }

        public MainWindow()
        {
            //MODIFY ALL UI ELEMENTS
            //MainMenu
            mainMenu.MM_singlePlayer.Click += MM_singlePlayer_Click;
            mainMenu.MM_twoPlayer.Click += MM_twoPlayer_Click;
            mainMenu.MM_scoreBoards.Click += MM_scoreBoards_Click;
            //Menus
            SP_modeSelect.SPMS_classic.Click += SPMS_classic_Click;
            SP_modeSelect.SPMS_timed.Click += SPMS_timed_Click;
            SP_modeSelect.SPMS_marathon.Click += SPMS_Marathon_Click;
            SP_modeSelect.SPMS_back.Click += SPMS_back_Click;

            TP_modeSelect.TPMS_classic.Click += TPMS_classic_Click;
            TP_modeSelect.TPMS_timed.Click += TPMS_timed_Click;
            TP_modeSelect.TPMS_marathon.Click += TPMS_marathon_Click;
            TP_modeSelect.TPMS_back.Click += TPMS_back_Click;

            scoreMenu.SM_back.Click += SM_back_Click;

            //Games
            SP_gameView.SPG_pause.Click += SPG_pause_Click;
            SP_gameView.SPG_save.Click += SPG_save_Click;
            SP_gameView.SPG_quit.Click += SPG_quit_Click;

            TP_gameView.TPG_pause.Click += TPG_pause_Click;
            TP_gameView.TPG_save.Click += TPG_save_Click;
            TP_gameView.TPG_quit.Click += TPG_quit_Click;

            //Overlays
            pause.pause_quit.Click += pause_quit_Click;
            pause.pause_continue.Click += pause_continue_Click;

            quit.quit_yes.Click += quit_yes_Click;
            quit.quit_no.Click += quit_no_Click;
            quit.Margin = new Thickness(0, 60, 0, 0);

            SP_gameSummary.SPGS_mainMenu.Click += SPGS_mainMenu_Click;
            SP_gameSummary.SPGS_playAgain.Click += SPGS_playAgain_Click;

            TP_gameSummary.TPGS_mainMenu.Click += TPGS_mainMenu_Click;
            TP_gameSummary.TPGS_playAgain.Click += TPGS_playAgain_Click;
            //Other
            saveDialog.DefaultExt = ".tetris";
            saveDialog.Filter = "Tetris Games (.tetris)|*.tetris";
            saveDialog.ValidateNames = true;
            saveDialog.Title = "Save Tetris Game";
            saveDialog.OverwritePrompt = true;
            saveDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGames";
            saveDialog.CreatePrompt = true;
            saveDialog.AddExtension = true;
            saveDialog.CheckPathExists = true;

            //Overlay Canvas Background
            backCanvas.Background = new SolidColorBrush(Colors.Black);
            backCanvas.Background.Opacity = .25;

            backCanvas2.Background = new SolidColorBrush(Colors.Black);
            backCanvas2.Background.Opacity = .25;

            //Instantiate score manager
            csm = new ScoreManager();

            //Key defaults
            P1Left = Key.A;
            P1Right = Key.D;
            P1Down = Key.S;
            P1Drop = Key.Space;
            P1Rotate = Key.W;
            P2Left = Key.Left;
            P2Right = Key.Right;
            P2Down = Key.Down;
            P2Drop = Key.RightShift;
            P2Rotate = Key.Up;
            PauseKey = Key.Escape;

            InitializeComponent();

            //Play background music
            string songPath = "Sound\\TetrisThemeSong.wav";
            SoundPlayer player = new SoundPlayer(songPath);
            player.PlayLooping();

            mainPanel.Children.Add(mainMenu);
        }        

        /************
         * GAME END
         ************/
        void soloGame_GameEnd()
        {
            /*
             * These statements must be dispatched out of this thread
             * -a
             */
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
                {
                    SP_gameView.SoloGame.Stop();
                    SP_gameView.PaintTimer.Stop();
                    int finalScore = SP_gameView.SoloGame.CurrentScore;
                    SP_gameSummary.SPGS_score.Content = finalScore;
                    SP_gameSummary.SPGS_lines.Content = SP_gameView.SoloGame.LinesCleared;
                    if (SP_gameView.GetGameMode() == GameMode.Timed)
                    {
                        SP_gameSummary.SPGS_time.Content = "02:00";
                    }
                    else
                    {
                        SP_gameSummary.SPGS_time.Content = SP_gameView.TimerLabel.Content;
                    }

                    if (csm.IsHighScore(finalScore))
                    {
                        SP_gameSummary.AHS_type.Content = "New High Score!!";
                        SP_gameSummary.AHS_type.FontWeight = FontWeights.Bold;
                    }
                    else
                    {
                        SP_gameSummary.AHS_type.Content = "Submit your score:";
                        SP_gameSummary.AHS_type.FontWeight = FontWeights.Normal;
                    }

                    mainPanel.Children.Remove(backCanvas);
                    mainPanel.Children.Add(backCanvas);

                    mainPanel.Children.Remove(SP_gameSummary);
                    mainPanel.Children.Add(SP_gameSummary);
                }
            ));
        }

        void PlayerOneGame_GameEnd()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                TP_gameView.PauseGame();
                TP_gameView.PaintTimer.Stop();
                int playerOneScore = TP_gameView.PlayerOneGame.CurrentScore;
                int playerTwoScore = TP_gameView.PlayerTwoGame.CurrentScore;
                TP_gameSummary.TPGS_playerOne_score.Content = playerOneScore;
                TP_gameSummary.TPGS_playerTwo_score.Content = playerTwoScore;
                TP_gameSummary.TPGS_playerOne_lines.Content = TP_gameView.PlayerOneGame.LinesCleared;
                TP_gameSummary.TPGS_playerTwo_lines.Content = TP_gameView.PlayerTwoGame.LinesCleared;
                if (TP_gameView.GetGameMode() == GameMode.Timed)
                {
                    TP_gameSummary.TPGS_time.Content = "02:00";
                }
                else
                {
                    TP_gameSummary.TPGS_time.Content = TP_gameView.TimerLabel.Content;
                }

                if (csm.IsHighScore(playerOneScore))
                {
                    TP_gameSummary.AHS_playerOne_type.Content = "New High Score!!";
                    TP_gameSummary.AHS_playerOne_type.FontWeight = FontWeights.Bold;
                }
                else
                {
                    TP_gameSummary.AHS_playerOne_type.Content = "Submit your score:";
                    TP_gameSummary.AHS_playerOne_type.FontWeight = FontWeights.Normal;
                }
                if (csm.IsHighScore(playerTwoScore))
                {
                    TP_gameSummary.AHS_playerTwo_type.Content = "New High Score!!";
                    TP_gameSummary.AHS_playerTwo_type.FontWeight = FontWeights.Bold;
                }
                else
                {
                    TP_gameSummary.AHS_playerTwo_type.Content = "Submit your score:";
                    TP_gameSummary.AHS_playerTwo_type.FontWeight = FontWeights.Normal;
                }

                if (playerOneScore > playerTwoScore)
                {
                    TP_gameSummary.TPGS_winner.Content = "Player One Wins!";
                }
                else if (playerTwoScore > playerOneScore)
                {
                    TP_gameSummary.TPGS_winner.Content = "Player Two Wins!";
                }
                else
                {
                    TP_gameSummary.TPGS_winner.Content = "It's a tie!";
                }

                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Add(backCanvas);

                mainPanel.Children.Remove(TP_gameSummary);
                mainPanel.Children.Add(TP_gameSummary);
            }
            ));
        }

        void PlayerTwoGame_GameEnd()
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                TP_gameView.PauseGame();
                TP_gameView.PaintTimer.Stop();
                int playerOneScore = TP_gameView.PlayerOneGame.CurrentScore;
                int playerTwoScore = TP_gameView.PlayerTwoGame.CurrentScore;
                TP_gameSummary.TPGS_playerOne_score.Content = playerOneScore;
                TP_gameSummary.TPGS_playerTwo_score.Content = playerTwoScore;
                TP_gameSummary.TPGS_playerOne_lines.Content = TP_gameView.PlayerOneGame.LinesCleared;
                TP_gameSummary.TPGS_playerTwo_lines.Content = TP_gameView.PlayerTwoGame.LinesCleared;
                if (TP_gameView.GetGameMode() == GameMode.Timed)
                {
                    TP_gameSummary.TPGS_time.Content = "02:00";
                }
                else
                {
                    TP_gameSummary.TPGS_time.Content = TP_gameView.TimerLabel.Content;
                }

                if (csm.IsHighScore(playerOneScore))
                {
                    TP_gameSummary.AHS_playerOne_type.Content = "New High Score!!";
                    TP_gameSummary.AHS_playerOne_type.FontWeight = FontWeights.Bold;
                }
                else
                {
                    TP_gameSummary.AHS_playerOne_type.Content = "Submit your score:";
                    TP_gameSummary.AHS_playerOne_type.FontWeight = FontWeights.Normal;
                }
                if (csm.IsHighScore(playerTwoScore))
                {
                    TP_gameSummary.AHS_playerTwo_type.Content = "New High Score!!";
                    TP_gameSummary.AHS_playerTwo_type.FontWeight = FontWeights.Bold;
                }
                else
                {
                    TP_gameSummary.AHS_playerTwo_type.Content = "Submit your score:";
                    TP_gameSummary.AHS_playerTwo_type.FontWeight = FontWeights.Normal;
                }

                if (playerOneScore > playerTwoScore)
                {
                    TP_gameSummary.TPGS_winner.Content = "Player One Wins!";
                }
                else if (playerTwoScore > playerOneScore)
                {
                    TP_gameSummary.TPGS_winner.Content = "Player Two Wins!";
                }
                else
                {
                    TP_gameSummary.TPGS_winner.Content = "It's a tie!";
                }

                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Add(backCanvas);

                mainPanel.Children.Remove(TP_gameSummary);
                mainPanel.Children.Add(TP_gameSummary);
            }
            ));
        }

        //EVENT HANDLERS--------------------------------------------------------------------------------------------

        //Main Menu
        void MM_singlePlayer_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Add(SP_modeSelect);
        }

        void MM_twoPlayer_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Add(TP_modeSelect);
        }

        void MM_scoreBoards_Click(object sender, RoutedEventArgs e)
        {
            scoreMenu.UpdateScores();
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(scoreMenu);
            mainPanel.Children.Add(scoreMenu);
        }

        //Mode Select

        //Single Player
        void SPMS_classic_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.NewGame(GameMode.Classic);
            SP_gameView.SoloGame.GameEnd += soloGame_GameEnd;
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(SP_gameView);
            mainPanel.Children.Add(SP_gameView);
        }

        void SPMS_timed_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.NewGame(GameMode.Timed);
            SP_gameView.SoloGame.GameEnd += soloGame_GameEnd;
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(SP_gameView);
            mainPanel.Children.Add(SP_gameView);
        }

        void SPMS_Marathon_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.NewGame(GameMode.Marathon);
            SP_gameView.SoloGame.GameEnd += soloGame_GameEnd;
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(SP_gameView);
            mainPanel.Children.Add(SP_gameView);
        }

        void SPMS_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
        }

        //Two Player
        void TPMS_classic_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.NewGame(GameMode.Classic);
            TP_gameView.PlayerOneGame.GameEnd += PlayerOneGame_GameEnd;
            TP_gameView.PlayerTwoGame.GameEnd += PlayerTwoGame_GameEnd;
            mainPanel.Children.Remove(TP_modeSelect);

            mainPanel.Children.Remove(TP_gameView);
            mainPanel.Children.Add(TP_gameView);
        }

        void TPMS_timed_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.NewGame(GameMode.Timed);
            TP_gameView.PlayerOneGame.GameEnd += PlayerOneGame_GameEnd;
            TP_gameView.PlayerTwoGame.GameEnd += PlayerTwoGame_GameEnd;
            mainPanel.Children.Remove(TP_modeSelect);

            mainPanel.Children.Remove(TP_gameView);
            mainPanel.Children.Add(TP_gameView);
        }

        void TPMS_marathon_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.NewGame(GameMode.Marathon);
            TP_gameView.PlayerOneGame.GameEnd += PlayerOneGame_GameEnd;
            TP_gameView.PlayerTwoGame.GameEnd += PlayerTwoGame_GameEnd;
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Remove(TP_gameView);
            mainPanel.Children.Add(TP_gameView);
        }

        void TPMS_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
        }

        //Score Menu
        void SM_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(scoreMenu);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
        }

        //Game Views

        //Single Player
        void SPG_pause_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);
        }

        void SPG_save_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            // http://stackoverflow.com/questions/5622854/how-do-i-show-a-save-as-dialog-in-wpf
            string file = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            file += " Solo";
            file += (SP_gameView.GetGameMode()).ToString();
            saveDialog.FileName = file;

            Nullable<bool> result = saveDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                file = saveDialog.FileName;
                //TODO Save document
            }
        }

        void SPG_quit_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            mainPanel.Children.Remove(backCanvas2);
            mainPanel.Children.Remove(quit);
            mainPanel.Children.Add(backCanvas2);
            mainPanel.Children.Add(quit);
        }

        // Two Player
        void TPG_pause_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);
        }

        void TPG_save_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            // http://stackoverflow.com/questions/5622854/how-do-i-show-a-save-as-dialog-in-wpf

            string file = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
            file += " Duo";
            file += (TP_gameView.GetGameMode()).ToString();
            saveDialog.FileName = file;

            Nullable<bool> result = saveDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                file = saveDialog.FileName;
                //TODO Save document
            }
        }

        void TPG_quit_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            mainPanel.Children.Remove(backCanvas2);
            mainPanel.Children.Remove(quit);
            mainPanel.Children.Add(backCanvas2);
            mainPanel.Children.Add(quit);
        }

        //Overlays

        //Pause
        void pause_quit_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(backCanvas2);
            mainPanel.Children.Remove(quit);
            mainPanel.Children.Add(backCanvas2);
            mainPanel.Children.Add(quit);
        }
        void pause_continue_Click(object sender, RoutedEventArgs e)
        {
            if (SP_gameView.SoloGame != null)
            {
                SP_gameView.ResumeGame();
            }
            else
            {
                TP_gameView.ResumeGame();
            }
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
        }

        //Quit
        void quit_yes_Click(object sender, RoutedEventArgs e)
        {
            if (SP_gameView.SoloGame != null)
            {
                SP_gameView.SoloGame.QuitGame();
            }
            else
            {
                TP_gameView.PlayerOneGame.QuitGame();
            }
        }
        void quit_no_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(backCanvas2);
            mainPanel.Children.Remove(quit);
        }

        //Single Player Game Summary

        void SPGS_mainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (SP_gameSummary.AHS_name.Text.ToCharArray().Length > 10)
            {
                SP_gameSummary.AHS_chars.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (!String.IsNullOrEmpty(SP_gameSummary.AHS_name.Text))
                {
                    SP_gameSummary.AddScore();
                }
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(SP_gameSummary);
                SP_gameSummary.AHS_chars.Visibility = System.Windows.Visibility.Collapsed;

                SP_gameView.SoloGame = null;

                mainPanel.Children.Remove(mainMenu);
                mainPanel.Children.Add(mainMenu);
            }
        }

        void SPGS_playAgain_Click(object sender, RoutedEventArgs e)
        {
            if (SP_gameSummary.AHS_name.Text.ToCharArray().Length > 10)
            {
                SP_gameSummary.AHS_chars.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                if (!String.IsNullOrEmpty(SP_gameSummary.AHS_name.Text))
                {
                    SP_gameSummary.AddScore();
                }
                mainPanel.Children.Remove(SP_gameView);
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(SP_gameSummary);
                SP_gameSummary.AHS_chars.Visibility = System.Windows.Visibility.Collapsed;

                if (SP_gameView.GetGameMode() == GameMode.Classic)
                {
                    SP_gameView.SoloGame = null;
                    SPMS_classic_Click(null, null);
                }
                else if (SP_gameView.GetGameMode() == GameMode.Marathon)
                {
                    SP_gameView.SoloGame = null;
                    SPMS_Marathon_Click(null, null);
                }
                else
                {
                    SP_gameView.SoloGame = null;
                    SPMS_timed_Click(null, null);
                }
            }
        }

        //Two Player Game Summary

        void TPGS_mainMenu_Click(object sender, RoutedEventArgs e)
        {
            if (TP_gameSummary.AHS_playerOne_name.Text.ToCharArray().Length > 10 || TP_gameSummary.AHS_playerTwo_name.Text.ToCharArray().Length > 10)
            {
                if (TP_gameSummary.AHS_playerOne_name.Text.ToCharArray().Length > 10)
                {
                    TP_gameSummary.AHS_playerOne_chars.Visibility = System.Windows.Visibility.Visible;
                }

                if (TP_gameSummary.AHS_playerTwo_name.Text.ToCharArray().Length > 10)
                {
                    TP_gameSummary.AHS_playerTwo_chars.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(TP_gameSummary.AHS_playerOne_name.Text))
                {
                    TP_gameSummary.PlayerOne_AddScore();
                }
                if (!String.IsNullOrEmpty(TP_gameSummary.AHS_playerTwo_name.Text))
                {
                    TP_gameSummary.PlayerTwo_AddScore();
                }
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(TP_gameSummary);
                TP_gameSummary.AHS_playerOne_chars.Visibility = System.Windows.Visibility.Collapsed;
                TP_gameSummary.AHS_playerTwo_chars.Visibility = System.Windows.Visibility.Collapsed;

                TP_gameView.PlayerOneGame = null;
                TP_gameView.PlayerTwoGame = null;

                mainPanel.Children.Remove(mainMenu);
                mainPanel.Children.Add(mainMenu);
            }
        }

        void TPGS_playAgain_Click(object sender, RoutedEventArgs e)
        {
            if (TP_gameSummary.AHS_playerOne_name.Text.ToCharArray().Length > 10 || TP_gameSummary.AHS_playerTwo_name.Text.ToCharArray().Length > 10)
            {
                if (TP_gameSummary.AHS_playerOne_name.Text.ToCharArray().Length > 10)
                {
                    TP_gameSummary.AHS_playerOne_chars.Visibility = System.Windows.Visibility.Visible;
                }

                if (TP_gameSummary.AHS_playerTwo_name.Text.ToCharArray().Length > 10)
                {
                    TP_gameSummary.AHS_playerTwo_chars.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(TP_gameSummary.AHS_playerOne_name.Text))
                {
                    TP_gameSummary.PlayerOne_AddScore();
                }
                if (!String.IsNullOrEmpty(TP_gameSummary.AHS_playerTwo_name.Text))
                {
                    TP_gameSummary.PlayerTwo_AddScore();
                }
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(TP_gameSummary);
                TP_gameSummary.AHS_playerOne_chars.Visibility = System.Windows.Visibility.Collapsed;
                TP_gameSummary.AHS_playerTwo_chars.Visibility = System.Windows.Visibility.Collapsed;

                TP_gameView.PlayerOneGame = null;
                TP_gameView.PlayerTwoGame = null;

                if (TP_gameView.GetGameMode() == GameMode.Classic)
                {
                    TPMS_classic_Click(null, null);
                }
                else if (TP_gameView.GetGameMode() == GameMode.Marathon)
                {
                    TPMS_marathon_Click(null, null);
                }
                else
                {
                    TPMS_timed_Click(null, null);
                }
            }
        }


        //KEY BINDINGS--------------------------------------------------------------------
        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            /*By default:
            * Player 1 has WASD
            * Player 2 has arrow keys
            */
            bool isTwoPlayerGame = TP_gameView.PlayerOneGame == null ? false : true;
            Key k = e.Key;
            if (isTwoPlayerGame)
            {
                if (k == P1Left)
                {
                    TP_gameView.PlayerOneGame.MoveLeft();
                }
                else if (k == P1Right)
                {
                    TP_gameView.PlayerOneGame.MoveRight();
                }
                else if (k == P1Down)
                {
                    TP_gameView.PlayerOneGame.MoveCurrentDown();
                }
                else if (k == P1Drop)
                {
                    TP_gameView.PlayerOneGame.HardDrop();
                }
                else if (k == P1Rotate)
                {
                    TP_gameView.PlayerOneGame.RotateCurrent();
                }
                else if (k == P2Left)
                {
                    TP_gameView.PlayerTwoGame.MoveLeft();
                }
                else if (k == P2Right)
                {
                    TP_gameView.PlayerTwoGame.MoveRight();
                }
                else if (k == P2Down)
                {
                    TP_gameView.PlayerTwoGame.MoveCurrentDown();
                }
                else if (k == P2Drop)
                {
                    TP_gameView.PlayerTwoGame.HardDrop();
                }
                else if (k == P2Rotate)
                {
                    TP_gameView.PlayerTwoGame.RotateCurrent();
                }
                else if (k == PauseKey)
                {
                    TPG_pause_Click(null, null);
                }
                //else if(k == Key.V)
                //{
                //    TP_gameView.PlayerTwoGame.AddRowSansOne();
                //}
            }
            else
            {
                if (k == P1Left)
                {
                    SP_gameView.SoloGame.MoveLeft();
                }
                else if (k == P1Right)
                {
                    SP_gameView.SoloGame.MoveRight();
                }
                else if (k == P1Down)
                {
                    SP_gameView.SoloGame.MoveCurrentDown();
                }
                else if (k == P1Drop)
                {
                    SP_gameView.SoloGame.HardDrop();
                }
                else if (k == P1Rotate)
                {
                    SP_gameView.SoloGame.RotateCurrent();
                }
                else if (k == PauseKey)
                {
                    SPG_pause_Click(null, null);
                }
                else if (k == Key.R)
                {
                    SP_gameView._rainbowMode = !SP_gameView._rainbowMode;
                }
            }
        }
    }
}