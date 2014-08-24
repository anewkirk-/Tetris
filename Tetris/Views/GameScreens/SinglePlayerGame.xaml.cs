using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
//using System.Threading;
//using System.Threading.Tasks;
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
        public Game soloGame { get; set; }
        public System.Timers.Timer PaintTimer { get; set; }
        private List<Rectangle> rs = new List<Rectangle>();

        public SinglePlayerGame()
        {
            InitializeComponent();
        }

        public void NewGame(GameMode type)
        {
            PaintTimer = new System.Timers.Timer(250);
            PaintTimer.Elapsed += PaintTimer_Elapsed;
            soloGame = new Game(type);
            soloGame.Start();
            PaintTimer.Start();
        }

        public void PaintTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke((Action)(() => { DisplayTetriminos(); }));
        }

        public GameMode GetGameMode()
        {
            return soloGame.Mode;
        }

        public void PauseGame()
        {
            PaintTimer.Stop();
            soloGame.Stop();
        }

        public void ResumeGame()
        {
            PaintTimer.Start();
            soloGame.Start();
        }

        public Rectangle CreateRectangle()
        {
            Rectangle rect = new Rectangle();
            rect.Fill = (new SolidColorBrush(Colors.AliceBlue));
            return rect;
        }

        public void DisplayTetriminos()
        {
            foreach (Rectangle r in rs)
            {
                SPG_playerOne_grid.Children.Remove(r);
            }

            Rectangle rect = null;
            foreach (Tetrimino t in soloGame.GameBoard)
            {
                foreach (Tetris.Models.TetriminoBag.Points p in t.Blocks)
                {
                    rect = CreateRectangle();
                    rs.Add(rect);
                    //Color i Tetrimino
                    if (t == soloGame.tBag[0])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Cyan));

                    }
                    //Color j Tetrimino
                    if (t == soloGame.tBag[1])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Blue));

                    }
                    //Color l Tetrimino
                    if (t == soloGame.tBag[2])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Orange));

                    }
                    //Color o Tetrimino
                    if (t == soloGame.tBag[3])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Yellow));

                    }
                    //Color s Tetrimino
                    if (t == soloGame.tBag[4])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Lime));

                    }
                    //Color t Tetrimino
                    if (t == soloGame.tBag[5])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.DarkMagenta));

                    }
                    //Color z Tetrimino
                    if (t == soloGame.tBag[6])
                    {
                        rect.Fill = (new SolidColorBrush(Colors.Red));

                    }

                    SPG_playerOne_grid.Children.Add(rect);
                    Grid.SetColumn(rect, p.X);
                    Grid.SetRow(rect, p.Y);
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