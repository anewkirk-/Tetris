using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.TetriminoBag
{
    public class Tetrimino
    {
        public List<Point> Blocks;

        public void RotateRight()
        {

        }

        public void Fall()
        {

        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
