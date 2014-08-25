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
            PaintTimer = new System.Timers.Timer(100);
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

            List<SolidColorBrush> TetriminoColors = new List<SolidColorBrush>();
            TetriminoColors.Add(new SolidColorBrush(Colors.Cyan));
            TetriminoColors.Add(new SolidColorBrush(Colors.Blue));
            TetriminoColors.Add(new SolidColorBrush(Colors.Orange));
            TetriminoColors.Add(new SolidColorBrush(Colors.Yellow));
            TetriminoColors.Add(new SolidColorBrush(Colors.Lime));
            TetriminoColors.Add(new SolidColorBrush(Colors.DarkMagenta));
            TetriminoColors.Add(new SolidColorBrush(Colors.Red));

            foreach (Tetrimino t in soloGame.GameBoard.ToList())
            {
                foreach (Tetris.Models.TetriminoBag.Points p in t.Blocks)
                {
                    rect = CreateRectangle();
                    if (t.GetType() == typeof(i_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(0);
                    }
                    if (t.GetType() == typeof(j_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(1);
                    }
                    if (t.GetType() == typeof(l_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(2);
                    }
                    if (t.GetType() == typeof(o_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(3);
                    }
                    if (t.GetType() == typeof(s_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(4);
                    }
                    if (t.GetType() == typeof(t_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(5);
                    }
                    if (t.GetType() == typeof(z_Tetrimino))
                    {
                        rect.Fill = TetriminoColors.ElementAt(6);
                    }
                    rs.Add(rect);
                    SPG_playerOne_grid.Children.Add(rect);
                    Grid.SetColumn(rect, p.X);
                    Grid.SetRow(rect, p.Y);
                }
            }
        }
    }
}