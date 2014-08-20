using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.Models.TetriminoBag
{
    public class Tetrimino
    {
        public SolidColorBrush color;

        public List<Points> Blocks;

        public void RotateRight()
        {

        }

        public void Fall()
        {

        }
    }

    public class Points
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
