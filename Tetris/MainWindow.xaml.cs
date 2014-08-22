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

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MainMenu mainMenu = new MainMenu();
        //Menus
            SinglePlayerModeSelect SP_modeSelect = new SinglePlayerModeSelect();
            TwoPlayerModeSelect TP_modeSelect = new TwoPlayerModeSelect();
            ScoresMenu scoreMenu = new ScoresMenu();
        //Games
            SinglePlayerGame SP_gameView = new SinglePlayerGame();
            TwoPlayerGame TP_gameView = new TwoPlayerGame();
        //Overlays
            AddHighScore newHighScore = new AddHighScore();
            PauseScreen pause = new PauseScreen();
            QuitConfirm quit = new QuitConfirm();
            SinglePlayerGameSummary SP_gameSummary = new SinglePlayerGameSummary();
            TwoPlayerGameSummary TP_gameSummary = new TwoPlayerGameSummary();
        //Other
            SaveFileDialog saveDialog = new SaveFileDialog();
        //Overlay Canvas Background
            Canvas backCanvas = new Canvas();
            Canvas backCanvas2 = new Canvas();
        
            
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

            
            InitializeComponent();

            mainPanel.Children.Add(mainMenu);

        }

        

        

        

        

        //EVENT HANDLERS--------------------------------------------------------------------------------------------

            //Main Menu
                void MM_singlePlayer_Click(object sender, RoutedEventArgs e)
                {
                    mainPanel.Children.Remove(mainMenu);
                    mainPanel.Children.Add(SP_modeSelect);
                }

                void MM_twoPlayer_Click(object sender, RoutedEventArgs e)
                {
                    mainPanel.Children.Remove(mainMenu);
                    mainPanel.Children.Add(TP_modeSelect);
                }

                void MM_scoreBoards_Click(object sender, RoutedEventArgs e)
                {
                    mainPanel.Children.Remove(mainMenu);
                    mainPanel.Children.Add(scoreMenu);
                }

            //Mode Select

                //Single Player
                    void SPMS_classic_Click(object sender, RoutedEventArgs e)
                    {
                        SP_gameView.NewGame(GameMode.Classic);
                        mainPanel.Children.Remove(SP_modeSelect);
                        mainPanel.Children.Add(SP_gameView);
                    }

                    void SPMS_timed_Click(object sender, RoutedEventArgs e)
                    {
                        SP_gameView.NewGame(GameMode.Timed);
                        mainPanel.Children.Remove(SP_modeSelect);
                        mainPanel.Children.Add(SP_gameView);
                    }

                    void SPMS_Marathon_Click(object sender, RoutedEventArgs e)
                    {
                        SP_gameView.NewGame(GameMode.Marathon);
                        mainPanel.Children.Remove(SP_modeSelect);
                        mainPanel.Children.Add(SP_gameView);
                    }
                    
                    void SPMS_back_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(SP_modeSelect);
                        mainPanel.Children.Add(mainMenu);
                    }
                    
                //Two Player
                    void TPMS_classic_Click(object sender, RoutedEventArgs e)
                    {
                        TP_gameView.NewGame(GameMode.Classic);
                        mainPanel.Children.Remove(TP_modeSelect);
                        mainPanel.Children.Add(TP_gameView);
                    }

                    void TPMS_timed_Click(object sender, RoutedEventArgs e)
                    {
                        TP_gameView.NewGame(GameMode.Timed);
                        mainPanel.Children.Remove(TP_modeSelect);
                        mainPanel.Children.Add(TP_gameView);
                    }

                    void TPMS_marathon_Click(object sender, RoutedEventArgs e)
                    {
                        TP_gameView.NewGame(GameMode.Marathon);
                        mainPanel.Children.Remove(TP_modeSelect);
                        mainPanel.Children.Add(TP_gameView);
                    }
                    
                    void TPMS_back_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(TP_modeSelect);
                        mainPanel.Children.Add(mainMenu);
                    }

                //Score Menu
                    void SM_back_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(scoreMenu);
                        mainPanel.Children.Add(mainMenu);
                    }

            //Game Views

                //Single Player
                    void SPG_pause_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO Pause Game
                        mainPanel.Children.Add(backCanvas);
                        mainPanel.Children.Add(pause);
                    }

                    void SPG_save_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO Pause Game
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
                        //TODO Pause Game
                        mainPanel.Children.Add(backCanvas);
                        mainPanel.Children.Add(pause);

                        mainPanel.Children.Add(backCanvas2);
                        mainPanel.Children.Add(quit);
                    }

                // Two Player
                    void TPG_pause_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO Pause Game
                        mainPanel.Children.Add(backCanvas);
                        mainPanel.Children.Add(pause);
                    }

                    void TPG_save_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO Pause Game
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
                        //TODO Pause Game
                        mainPanel.Children.Add(backCanvas);
                        mainPanel.Children.Add(pause);

                        mainPanel.Children.Add(backCanvas2);
                        mainPanel.Children.Add(quit);
                    }

            //Overlays

                //Pause
                    void pause_quit_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Add(backCanvas2);
                        mainPanel.Children.Add(quit);
                    }
                    void pause_continue_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO Resume Game
                        mainPanel.Children.Remove(backCanvas);
                        mainPanel.Children.Remove(pause);
                    }

                //Quit

                    void quit_yes_Click(object sender, RoutedEventArgs e)
                    {
                        //TODO End Game
                        mainPanel.Children.Remove(TP_gameView);
                        mainPanel.Children.Remove(SP_gameView);
                        mainPanel.Children.Add(mainMenu);

                        mainPanel.Children.Remove(backCanvas);
                        mainPanel.Children.Remove(pause);

                        mainPanel.Children.Remove(backCanvas2);
                        mainPanel.Children.Remove(quit);
                    }
                    void quit_no_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(backCanvas2);
                        mainPanel.Children.Remove(quit);
                    }

                    private void Window_KeyDown_1(object sender, KeyEventArgs e)
                    {
                        switch (e.Key)
                        {
                            case Key.V:
                                SP_gameView.soloGame.Tick(null,null);
                                break;
                            case Key.Space:
                                SP_gameView.DisplayTetriminos();
                                break;
                            case Key.Escape:
                                Environment.Exit(0);
                                break;
                        }
                    }
    }
}