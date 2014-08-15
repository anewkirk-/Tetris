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
            SinglePlayerGameSummary SP_gameSummary = new SinglePlayerGameSummary();
            TwoPlayerGameSummary TP_gameSummary = new TwoPlayerGameSummary();
        //Overlay Canvas Background
            Canvas backCanvas = new Canvas();
            
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


                //Overlays
                    pause.pause_continue.Click += pause_continue_Click;


                //Overlay Canvas Background
                    backCanvas.Background = new SolidColorBrush(Colors.Black);
                    backCanvas.Background.Opacity = .25;

            
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
                        mainPanel.Children.Add(backCanvas);
                        mainPanel.Children.Add(pause);
                    }

                    void SPMS_timed_Click(object sender, RoutedEventArgs e)
                    {
                        throw new NotImplementedException();
                    }

                    void SPMS_Marathon_Click(object sender, RoutedEventArgs e)
                    {
                        throw new NotImplementedException();
                    }
                    
                    void SPMS_back_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(SP_modeSelect);
                        mainPanel.Children.Add(mainMenu);
                    }
                    
                //Two Player
                    void TPMS_classic_Click(object sender, RoutedEventArgs e)
                    {
                        throw new NotImplementedException();
                    }

                    void TPMS_timed_Click(object sender, RoutedEventArgs e)
                    {
                        throw new NotImplementedException();
                    }

                    void TPMS_marathon_Click(object sender, RoutedEventArgs e)
                    {
                        throw new NotImplementedException();
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


            //Overlays

                //Pause
                    void pause_continue_Click(object sender, RoutedEventArgs e)
                    {
                        mainPanel.Children.Remove(backCanvas);
                        mainPanel.Children.Remove(pause);
                    }
    }
}
