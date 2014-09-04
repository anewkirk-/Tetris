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
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.ComponentModel;
using Tetris.Converters;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        KeyBindingsMenu bindingsMenu = new KeyBindingsMenu();

        //Other
        OpenFileDialog openDialog = new OpenFileDialog();
        SaveFileDialog saveDialog = new SaveFileDialog();
        private ScoreManager csm;

        //Overlay Canvas Background
        Canvas backCanvas = new Canvas();
        Canvas backCanvas2 = new Canvas();

        //Sound Buttons
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _musicMuted = false;
        public bool MusicMuted
        {
            get
            {
                return _musicMuted;
            }
            set
            {
                _musicMuted = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MusicMuted"));
                }
            }
        }
        private bool _sfxMuted = false;
        public bool SFXMuted
        {
            get
            {
                return _sfxMuted;
            }
            set
            {
                _sfxMuted = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SFXMuted"));
                }
            }
        }

        public Sound SoundManager { get; set; }

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
            mainMenu.MM_options.Click += MM_options_Click;
            //Menus
            SP_modeSelect.SPMS_classic.Click += SPMS_classic_Click;
            SP_modeSelect.SPMS_timed.Click += SPMS_timed_Click;
            SP_modeSelect.SPMS_marathon.Click += SPMS_marathon_Click;
            SP_modeSelect.SPMS_load.Click += SPMS_load_Click;
            SP_modeSelect.SPMS_back.Click += SPMS_back_Click;

            TP_modeSelect.TPMS_classic.Click += TPMS_classic_Click;
            TP_modeSelect.TPMS_timed.Click += TPMS_timed_Click;
            TP_modeSelect.TPMS_marathon.Click += TPMS_marathon_Click;
            TP_modeSelect.TPMS_load.Click += TPMS_load_Click;
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

            bindingsMenu.KBM_back.Click += KBM_back_Click;
            bindingsMenu.DataContext = this;

            //Other
            openDialog.CheckPathExists = true;
            openDialog.CheckFileExists = true;
            openDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGames";

            saveDialog.ValidateNames = true;
            saveDialog.Title = "Save Tetris Game";
            saveDialog.OverwritePrompt = true;
            saveDialog.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\SavedGames";
            saveDialog.CreatePrompt = false;
            saveDialog.AddExtension = true;
            saveDialog.CheckPathExists = true;

            //Overlay Canvas Background
            backCanvas.Background = new SolidColorBrush(Colors.Black);
            backCanvas.Background.Opacity = .25;

            backCanvas2.Background = new SolidColorBrush(Colors.Black);
            backCanvas2.Background.Opacity = .25;

            //Instantiate score manager
            csm = new ScoreManager();


            //
            SoundManager = new Sound();

            //Sound Buttons
            Binding musicVolume = new Binding("MusicMuted");
            musicVolume.Converter = (BoolToImageConverter)Application.Current.FindResource("MusicConverter");
            musicVolume.Source = this;
            musicVolume.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            mainMenu.MM_music.SetBinding(Button.ContentProperty, musicVolume);
            SP_modeSelect.SPMS_music.SetBinding(Button.ContentProperty, musicVolume);
            TP_modeSelect.TPMS_music.SetBinding(Button.ContentProperty, musicVolume);
            scoreMenu.SM_music.SetBinding(Button.ContentProperty, musicVolume);
            bindingsMenu.KBM_music.SetBinding(Button.ContentProperty, musicVolume);
            SP_gameView.SPG_music.SetBinding(Button.ContentProperty, musicVolume);
            TP_gameView.TPG_music.SetBinding(Button.ContentProperty, musicVolume);

            mainMenu.MM_music.DataContext = this;
            SP_modeSelect.SPMS_music.DataContext = this;
            TP_modeSelect.TPMS_music.DataContext = this;
            scoreMenu.SM_music.DataContext = this;
            bindingsMenu.KBM_music.DataContext = this;
            SP_gameView.SPG_music.DataContext = this;
            TP_gameView.TPG_music.DataContext = this;

            mainMenu.MM_music.Click += music_Click;
            SP_modeSelect.SPMS_music.Click += music_Click;
            TP_modeSelect.TPMS_music.Click += music_Click;
            scoreMenu.SM_music.Click += music_Click;
            bindingsMenu.KBM_music.Click += music_Click;
            SP_gameView.SPG_music.Click += music_Click;
            TP_gameView.TPG_music.Click += music_Click;

            Binding sfxVolume = new Binding("SFXMuted");
            sfxVolume.Converter = (BoolToImageConverter)Application.Current.FindResource("SFXConverter");
            sfxVolume.Source = this;
            sfxVolume.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            mainMenu.MM_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            SP_modeSelect.SPMS_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            TP_modeSelect.TPMS_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            scoreMenu.SM_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            bindingsMenu.KBM_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            SP_gameView.SPG_sfx.SetBinding(Button.ContentProperty, sfxVolume);
            TP_gameView.TPG_sfx.SetBinding(Button.ContentProperty, sfxVolume);

            mainMenu.MM_sfx.Click += sfx_Click;
            SP_modeSelect.SPMS_sfx.Click += sfx_Click;
            TP_modeSelect.TPMS_sfx.Click += sfx_Click;
            scoreMenu.SM_sfx.Click += sfx_Click;
            bindingsMenu.KBM_sfx.Click += sfx_Click;
            SP_gameView.SPG_sfx.Click += sfx_Click;
            TP_gameView.TPG_sfx.Click += sfx_Click;

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
                        if (SP_gameView.SoloGame.TimeElapsed < 120000)
                        {
                            if (SP_gameView.SoloGame.TimeElapsed > 59999)
                            {
                                SP_gameSummary.SPGS_time.Content = "01:" + ((int)((SP_gameView.SoloGame.TimeElapsed - 60000) / 1000));
                            }
                            else if (SP_gameView.SoloGame.TimeElapsed < 10000)
                            {
                                SP_gameSummary.SPGS_time.Content = "00:0" + ((int)(SP_gameView.SoloGame.TimeElapsed / 1000));
                            }
                            else
                            {
                                SP_gameSummary.SPGS_time.Content = "00:" + ((int)(SP_gameView.SoloGame.TimeElapsed / 1000));
                            }
                        }
                        else
                        {
                            SP_gameSummary.SPGS_time.Content = "02:00";
                        }
                    }
                    else
                    {
                        SP_gameSummary.SPGS_time.Content = SP_gameView.TimerLabel.Content;
                    }

                    if (finalScore == 0)
                    {
                        SP_gameSummary.AHS_name.Visibility = System.Windows.Visibility.Collapsed;
                        SP_gameSummary.AHS_type.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    else
                    {
                        SP_gameSummary.AHS_name.Visibility = System.Windows.Visibility.Visible;
                        SP_gameSummary.AHS_type.Visibility = System.Windows.Visibility.Visible;
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

                    SoundManager.PlayGameOverSFX();

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
                    if (TP_gameView.PlayerOneGame.TimeElapsed < 120000)
                    {
                        if (TP_gameView.PlayerOneGame.TimeElapsed > 59999)
                        {
                            TP_gameSummary.TPGS_time.Content = "01:" + ((int)((TP_gameView.PlayerOneGame.TimeElapsed - 60000) / 1000));
                        }
                        else if (TP_gameView.PlayerOneGame.TimeElapsed < 10000)
                        {
                            TP_gameSummary.TPGS_time.Content = "00:0" + ((int)(TP_gameView.PlayerOneGame.TimeElapsed / 1000));
                        }
                        else
                        {
                            TP_gameSummary.TPGS_time.Content = "00:" + ((int)(TP_gameView.PlayerOneGame.TimeElapsed / 1000));
                        }
                    }
                    else
                    {
                        TP_gameSummary.TPGS_time.Content = "02:00";
                    }
                }
                else
                {
                    TP_gameSummary.TPGS_time.Content = TP_gameView.TimerLabel.Content;
                }

                if (playerOneScore == 0)
                {
                    TP_gameSummary.AHS_playerOne_name.Visibility = System.Windows.Visibility.Collapsed;
                    TP_gameSummary.AHS_playerOne_type.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    TP_gameSummary.AHS_playerOne_name.Visibility = System.Windows.Visibility.Visible;
                    TP_gameSummary.AHS_playerOne_type.Visibility = System.Windows.Visibility.Visible;
                }
                if (playerTwoScore == 0)
                {
                    TP_gameSummary.AHS_playerTwo_name.Visibility = System.Windows.Visibility.Collapsed;
                    TP_gameSummary.AHS_playerTwo_type.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    TP_gameSummary.AHS_playerTwo_name.Visibility = System.Windows.Visibility.Visible;
                    TP_gameSummary.AHS_playerTwo_type.Visibility = System.Windows.Visibility.Visible;
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
                    if (TP_gameView.PlayerOneGame.TimeElapsed < 120000)
                    {
                        if (TP_gameView.PlayerOneGame.TimeElapsed > 59999)
                        {
                            TP_gameSummary.TPGS_time.Content = "01:" + ((int)((TP_gameView.PlayerOneGame.TimeElapsed - 60000) / 1000));
                        }
                        else if (SP_gameView.SoloGame.TimeElapsed < 10000)
                        {
                            TP_gameSummary.TPGS_time.Content = "00:0" + ((int)(TP_gameView.PlayerOneGame.TimeElapsed / 1000));
                        }
                        else
                        {
                            TP_gameSummary.TPGS_time.Content = "00:" + ((int)(TP_gameView.PlayerOneGame.TimeElapsed / 1000));
                        }
                    }
                    else
                    {
                        TP_gameSummary.TPGS_time.Content = "02:00";
                    }
                }
                else
                {
                    TP_gameSummary.TPGS_time.Content = TP_gameView.TimerLabel.Content;
                }

                if (playerOneScore == 0)
                {
                    TP_gameSummary.AHS_playerOne_name.Visibility = System.Windows.Visibility.Collapsed;
                    TP_gameSummary.AHS_playerOne_type.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    TP_gameSummary.AHS_playerOne_name.Visibility = System.Windows.Visibility.Visible;
                    TP_gameSummary.AHS_playerOne_type.Visibility = System.Windows.Visibility.Visible;
                }
                if (playerTwoScore == 0)
                {
                    TP_gameSummary.AHS_playerTwo_name.Visibility = System.Windows.Visibility.Collapsed;
                    TP_gameSummary.AHS_playerTwo_type.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    TP_gameSummary.AHS_playerTwo_name.Visibility = System.Windows.Visibility.Visible;
                    TP_gameSummary.AHS_playerTwo_type.Visibility = System.Windows.Visibility.Visible;
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

        //private void PlayAltBgMusic()
        //{
        //    StopBgMusic();
        //    string songPath = "Sound\\TetrisThemeSong.wav";
        //    MusicPlayer = new SoundPlayer(songPath);
        //    MusicPlayer.PlayLooping();
        //}

        //private void StopBgMusic()
        //{
        //    if (MusicPlayer != null)
        //    {
        //        MusicPlayer.Stop();
        //    }
        //}

        //Sound Buttons

        void music_Click(object sender, RoutedEventArgs e)
        {

            MusicMuted = !MusicMuted;
            if (backgroundMusic != null)
            {
                if (MusicMuted)
                {
                    backgroundMusic.Volume = 0;
                }
                else
                {
                    backgroundMusic.Volume = .5;
                }
            }
        }

        private void sfx_Click(object sender, RoutedEventArgs e)
        {

            SFXMuted = !SFXMuted;

            List<MediaPlayer> sfx = SoundManager.SFXList();
            if (sfx != null)
            {
                if (SFXMuted)
                {
                    foreach (MediaPlayer s in sfx)
                    {
                        s.Volume = 0;
                    }
                }
                else
                    foreach (MediaPlayer s in sfx)
                    {
                        s.Volume = 8;
                    }
            }
        }

        //EVENT HANDLERS--------------------------------------------------------------------------------------------

        //Main Menu
        void MM_singlePlayer_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Add(SP_modeSelect);
            UpdateSoundButtons();
        }

        void MM_twoPlayer_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Add(TP_modeSelect);
            UpdateSoundButtons();
        }

        void MM_scoreBoards_Click(object sender, RoutedEventArgs e)
        {
            scoreMenu.UpdateScores();
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Remove(scoreMenu);
            mainPanel.Children.Add(scoreMenu);
            UpdateSoundButtons();
        }

        void MM_options_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(bindingsMenu);
            UpdateSoundButtons();
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
            UpdateSoundButtons();
        }

        void SPMS_timed_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.NewGame(GameMode.Timed);
            SP_gameView.SoloGame.GameEnd += soloGame_GameEnd;
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(SP_gameView);
            mainPanel.Children.Add(SP_gameView);
            UpdateSoundButtons();
        }

        void SPMS_marathon_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.NewGame(GameMode.Marathon);
            SP_gameView.SoloGame.GameEnd += soloGame_GameEnd;
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(SP_gameView);
            mainPanel.Children.Add(SP_gameView);
            UpdateSoundButtons();
        }

        void SPMS_load_Click(object sender, RoutedEventArgs e)
        {
            openDialog.DefaultExt = ".tetris";
            openDialog.Filter = "Tetris Solo Games (.tetris)|*.tetris";

            Nullable<bool> result = openDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                string file = openDialog.FileName;
                DeserializeSoloGame(file);
            }
        }

        void SPMS_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(SP_modeSelect);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
            UpdateSoundButtons();
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
            UpdateSoundButtons();
        }

        void TPMS_timed_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.NewGame(GameMode.Timed);
            TP_gameView.PlayerOneGame.GameEnd += PlayerOneGame_GameEnd;
            TP_gameView.PlayerTwoGame.GameEnd += PlayerTwoGame_GameEnd;
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Remove(TP_gameView);
            mainPanel.Children.Add(TP_gameView);
            UpdateSoundButtons();
        }

        void TPMS_marathon_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.NewGame(GameMode.Marathon);
            TP_gameView.PlayerOneGame.GameEnd += PlayerOneGame_GameEnd;
            TP_gameView.PlayerTwoGame.GameEnd += PlayerTwoGame_GameEnd;
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Remove(TP_gameView);
            mainPanel.Children.Add(TP_gameView);
            UpdateSoundButtons();
        }

        void TPMS_load_Click(object sender, RoutedEventArgs e)
        {
            openDialog.DefaultExt = ".tetris2";
            openDialog.Filter = "Tetris Two Player Games (.tetris2)|*.tetris2";

            Nullable<bool> result = openDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                string file = openDialog.FileName;
                DeserializeTwoPlayerGame(file);
            }
        }

        void TPMS_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(TP_modeSelect);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
            UpdateSoundButtons();
        }

        //Score Menu
        void SM_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(scoreMenu);
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(mainMenu);
            UpdateSoundButtons();
        }

        //Game Views

        //Single Player
        void SPG_pause_Click(object sender, RoutedEventArgs e)
        {
            if (SP_gameView.SoloGame != null)
            {

                SP_gameView.PauseGame();
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(pause);
                mainPanel.Children.Add(backCanvas);
                mainPanel.Children.Add(pause);
            }
        }

        void SPG_save_Click(object sender, RoutedEventArgs e)
        {
            SP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            // http://stackoverflow.com/questions/5622854/how-do-i-show-a-save-as-dialog-in-wpf
            string file = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss ");
            file += (SP_gameView.GetGameMode()).ToString();
            saveDialog.FileName = file;
            saveDialog.DefaultExt = ".tetris";
            saveDialog.Filter = "Tetris Solo Games (.tetris) | *.tetris";

            Nullable<bool> result = saveDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                file = saveDialog.FileName;
                SerializeSoloGame(SP_gameView.SoloGame, file);
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
            if (TP_gameView.PlayerOneGame != null)
            {
                TP_gameView.PauseGame();
                mainPanel.Children.Remove(backCanvas);
                mainPanel.Children.Remove(pause);
                mainPanel.Children.Add(backCanvas);
                mainPanel.Children.Add(pause);
            }
        }

        void TPG_save_Click(object sender, RoutedEventArgs e)
        {
            TP_gameView.PauseGame();
            mainPanel.Children.Remove(backCanvas);
            mainPanel.Children.Remove(pause);
            mainPanel.Children.Add(backCanvas);
            mainPanel.Children.Add(pause);

            // http://stackoverflow.com/questions/5622854/how-do-i-show-a-save-as-dialog-in-wpf

            string file = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss ");
            file += (TP_gameView.GetGameMode()).ToString();
            saveDialog.FileName = file;
            saveDialog.DefaultExt = ".tetris2";
            saveDialog.Filter = "Tetris Two Player Games (.tetris2)|*.tetris2";

            Nullable<bool> result = saveDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                file = saveDialog.FileName;
                TwoPlayerSerWrapper w = new TwoPlayerSerWrapper();
                w.PlayerOneGame = TP_gameView.PlayerOneGame;
                w.PlayerTwoGame = TP_gameView.PlayerTwoGame;
                SerializeTwoPlayerGame(w, file);
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
                UpdateSoundButtons();
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
                    SPMS_marathon_Click(null, null);
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
                UpdateSoundButtons();
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

        private void KBM_back_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(bindingsMenu);
            mainPanel.Children.Add(mainMenu);
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
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P1Right)
                {
                    SoundManager.PlayMoveSFX();
                    TP_gameView.PlayerOneGame.MoveRight();
                }
                else if (k == P1Down)
                {
                    TP_gameView.PlayerOneGame.MoveCurrentDown();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P1Drop)
                {
                    TP_gameView.PlayerOneGame.HardDrop();
                    SoundManager.PlayCollisionSFX();
                }
                else if (k == P1Rotate)
                {
                    TP_gameView.PlayerOneGame.RotateCurrent();
                    SoundManager.PlayRotateSFX();
                }
                else if (k == P2Left)
                {
                    TP_gameView.PlayerTwoGame.MoveLeft();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P2Right)
                {
                    TP_gameView.PlayerTwoGame.MoveRight();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P2Down)
                {
                    TP_gameView.PlayerTwoGame.MoveCurrentDown();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P2Drop)
                {
                    TP_gameView.PlayerTwoGame.HardDrop();
                    SoundManager.PlayCollisionSFX();
                }
                else if (k == P2Rotate)
                {
                    TP_gameView.PlayerTwoGame.RotateCurrent();
                    SoundManager.PlayRotateSFX();
                }
                else if (k == PauseKey)
                {
                    TPG_pause_Click(null, null);
                    SoundManager.PlayPauseSFX();
                }

            }
            else if (SP_gameView.SoloGame != null)
            {
                if (k == P1Left)
                {
                    SP_gameView.SoloGame.MoveLeft();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P1Right)
                {
                    SP_gameView.SoloGame.MoveRight();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P1Down)
                {
                    SP_gameView.SoloGame.MoveCurrentDown();
                    SoundManager.PlayMoveSFX();
                }
                else if (k == P1Drop)
                {
                    SP_gameView.SoloGame.HardDrop();
                    SoundManager.PlayCollisionSFX();
                }
                else if (k == P1Rotate)
                {
                    SP_gameView.SoloGame.RotateCurrent();
                    SoundManager.PlayRotateSFX();
                }
                else if (k == PauseKey)
                {
                    SPG_pause_Click(null, null);
                    SoundManager.PlayPauseSFX();
                }
                else if (k == Key.R)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        SP_gameView._rainbowMode = true;
                        //PlayAltBgMusic();
                    }
                }
                else if (k == Key.X)
                {
                    if (Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftShift))
                    {
                        SP_gameView._rainbowMode = false;
                    }
                }
            }
        }

        //SERIALIZATION

        void SerializeSoloGame(Game w, string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, w);
        }

        private void DeserializeSoloGame(string file)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream InStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
                Game soloGame = (Game)formatter.Deserialize(InStream);
                soloGame.GameTimer = new System.Timers.Timer();
                soloGame.GameTimer.Interval = 500;
                soloGame.GameTimer.Elapsed += soloGame.Tick;
                soloGame.GameEnd += soloGame_GameEnd;
                InStream.Close();
                SP_gameView.NewGame(soloGame.Mode);
                SP_gameView.SoloGame.Stop();
                SP_gameView.PaintTimer.Stop();
                SP_gameView.SoloGame = soloGame;
                mainPanel.Children.Remove(SP_modeSelect);
                mainPanel.Children.Remove(SP_gameView);
                mainPanel.Children.Add(SP_gameView);
                UpdateSoundButtons();
                SP_gameView.SoloGame.Start();
                SP_gameView.PaintTimer.Start();
            }
            catch
            {
                // >.<" sorry
            }
        }

        void SerializeTwoPlayerGame(TwoPlayerSerWrapper w, string filePath)
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            formater.Serialize(stream, w);
        }

        private void DeserializeTwoPlayerGame(string file)
        {
            throw new NotImplementedException();
        }

        //Sound Update Buttons
        private void UpdateSoundButtons()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("MusicMuted"));
                PropertyChanged(this, new PropertyChangedEventArgs("SFXMuted"));
            }
        }
    }
}