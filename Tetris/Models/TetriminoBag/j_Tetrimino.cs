using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models.TetriminoBag
{
    public class j_Tetrimino : Tetrimino
    {
        public int position = 1;
        public List<Point> Blocks = new List<Point>()
        {
            new Point { X = 0, Y = 0 },
            new Point { X = 1, Y = 0 },
            new Point { X = 1, Y = 1 },
            new Point { X = 1, Y = 2 }
        };

        public void RotateRight()
        {
            if (position == 1)
            {
                Blocks[0].Y = Blocks[0].Y + 2;
                Blocks[1].X--;
                Blocks[1].Y++;
                Blocks[3].X++;
                Blocks[3].Y--;
            }
            if (position == 2)
            {
                Blocks[0].X = Blocks[0].X + 2;
                Blocks[1].X++;
                Blocks[1].Y++;
                Blocks[3].X--;
                Blocks[3].Y--;
            }
            if (position == 3)
            {
                Blocks[0].Y = Blocks[0].Y - 2;
                Blocks[1].X++;
                Blocks[1].Y--;
                Blocks[3].X--;
                Blocks[3].Y++;
            }
            if (position == 4)
            {
                Blocks[0].X = Blocks[0].X - 2;
                Blocks[1].X--;
                Blocks[1].Y--;
                Blocks[3].X++;
                Blocks[3].Y++;
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
