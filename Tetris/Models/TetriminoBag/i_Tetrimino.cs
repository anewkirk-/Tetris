using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.TetriminoBag
{
    public class i_Tetrimino : Tetrimino
    {
        private int position = 1;
        public List<Point> Blocks = new List<Point>()
        {
             new Point { X = 1, Y = 0 },
             new Point { X = 1, Y = 1, isCenter = true},
             new Point { X = 1, Y = 2 },
             new Point { X = 1, Y = 3 }
            
        };

        public void RotateRight()
        {
            if (position == 1)
            {
                Blocks[0].X--;
                Blocks[0].Y++;
                Blocks[2].X--;
                Blocks[2].Y++;
                Blocks[3].X = Blocks[3].X + 2;
                Blocks[3].Y = Blocks[3].Y - 2;
            }
            if (position == 2)
            {
                Blocks[0].X++;
                Blocks[0].Y++;
                Blocks[2].X--;
                Blocks[2].Y--;
                Blocks[3].X = Blocks[3].X - 2;
                Blocks[3].Y = Blocks[3].Y - 2;
            }
            if (position == 3)
            {
                Blocks[0].X++;
                Blocks[0].Y--;
                Blocks[2].X--;
                Blocks[2].Y++;
                Blocks[3].X = Blocks[3].X - 2;
                Blocks[3].Y = Blocks[3].Y - 2;
            }
            if (position == 4)
            {
                Blocks[0].X--;
                Blocks[0].Y--;
                Blocks[2].X++;
                Blocks[2].Y++;
                Blocks[3].X = Blocks[3].X + 2;
                Blocks[3].Y = Blocks[3].Y + 2;
            }
            if (position == 4)
            {
                position = 1;
            }
            else
            {
                position++;
            }
        }

        public void Fall()
        {
            for (int i = 0; i < 4; i++)
            {
                Blocks[i].X++;
            }
        }
    }
}
