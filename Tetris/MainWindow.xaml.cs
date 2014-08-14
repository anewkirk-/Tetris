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
            SinglePlayerModeSelect SP_modeSelect = new SinglePlayerModeSelect();
            TwoPlayerModeSelect TP_modeSelect = new TwoPlayerModeSelect();
            ScoresMenu scoreBoard = new ScoresMenu();

            SinglePlayerGame SP_gameView = new SinglePlayerGame();
            TwoPlayerGame TP_gameView = new TwoPlayerGame();


        //Overlays
        PauseScreen pause = new PauseScreen();
        //Overlay Canvas
        Canvas back = new Canvas();
            
        public MainWindow()
        {
            back.Background = new SolidColorBrush(Colors.Black);
            back.Background.Opacity = .25;

            
            InitializeComponent();

            mainMenu.MM_singlePlayer.Click += MM_singlePlayer_Click;

            mainPanel.Children.Add(mainMenu);

            

            

            //mainPanel.Children.Add(back);
            //mainPanel.Children.Add(pause);

        }







        //EVENT HANDLERS--------------------------------------------------------------------------------------------

        void MM_singlePlayer_Click(object sender, RoutedEventArgs e)
        {
            mainPanel.Children.Remove(mainMenu);
            mainPanel.Children.Add(SP_modeSelect);
        }


    }
}
