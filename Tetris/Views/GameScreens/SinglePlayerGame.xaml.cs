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
using Tetris.Models.TetriminoBag;

namespace Tetris.Views.GameScreens
{
    /// <summary>
    /// Interaction logic for SinglePlayerGame.xaml
    /// </summary>
    public partial class SinglePlayerGame : UserControl
    {

        Game soloGame;

        public SinglePlayerGame()
        {
            InitializeComponent();
        }

        public void NewGame(GameMode type)
        {
            soloGame = new Game(type);
            soloGame.Start();
<<<<<<< HEAD
            //DisplayTetrimino();
=======
            DisplayTetrimino();
>>>>>>> 7a04875b6f0563f7d733393389d5480bd8d7aaa5
        }

        public GameMode GetGameMode()
        {
            return soloGame.Mode;
        }

        public Rectangle CreateRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Fill = (new SolidColorBrush(Colors.AliceBlue));

            return rect;
        }

        public void DisplayTetriminos()
        {
            Rectangle rect = null;
            foreach(Tetrimino t in soloGame.GameBoard)
            {
                foreach (Tetris.Models.TetriminoBag.Points p in t.Blocks)
                {
                    rect = CreateRectangle();
                    //Color i Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[0])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Cyan));

                    }
                    //Color j Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[1])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Blue));

                    }
                    //Color l Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[2])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Orange));

                    }
                    //Color o Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[3])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Yellow));

                    }
                    //Color s Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[4])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Lime));

                    }
                    //Color t Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[5])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.DarkMagenta));

                    }
                    //Color z Tetrimino
                    if (soloGame.CurrentTetrimino == soloGame.tBag[6])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Red));

                    }

                    SPG_playerOne_grid.Children.Add(rect);
                    Grid.SetColumn(rect, p.Y);
                    Grid.SetRow(rect, p.X);
                }
            }
        }

        //Display the Row of blocks that are added when a "Tetris" occurs during multiplayer games
        public Rectangle DisplayRowOfBlocksMinusOne()
        {
            Rectangle rect = new Rectangle();
            foreach (Points pt in soloGame.RowOfBlocksMinusOne())
            {
                rect.Fill = (new SolidColorBrush(Colors.Green));
                SPG_playerOne_grid.Children.Add(rect);
                Grid.SetColumn(rect, pt.Y);
                Grid.SetRow(rect, pt.X);
            }
            return rect;
        }
    }
}