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

        public virtual void Rotate() { }

        public void Fall() 
        {
            foreach (Points p in Blocks.ToList())
            {
                p.Y++;
            }
        }

        public virtual void RotateBack() { }
    }

    public class Points
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
