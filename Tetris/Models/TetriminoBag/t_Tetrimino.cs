using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.Models.TetriminoBag
{
    public class t_Tetrimino : Tetrimino
    {
        public t_Tetrimino()
        {
            color = new SolidColorBrush(Color.FromRgb(152, 0, 255));
            Blocks = new List<Points>()
            {
                new Points { X = 1, Y = 3 },
                new Points { X = 1, Y = 4 },
                new Points { X = 0, Y = 4 },
                new Points { X = 1, Y = 5 }
            };
        }

        private int position = 1;
        private int preY0 = 0;
        private int preX0 = 0;
        private int preY2 = 0;
        private int preX2 = 0;
        private int preY3 = 0;
        private int preX3 = 0;

        public override void Rotate()
        {
            if (position == 1)
            {
                setPre();
                Blocks[0].X--;
                Blocks[0].Y++;
                Blocks[2].X++;
                Blocks[2].Y++;
                Blocks[3].X++;
                Blocks[3].Y--;
            }
            if (position == 2)
            {
                setPre();
                Blocks[0].Y++;
                Blocks[0].X++;
                Blocks[2].X++;
                Blocks[2].Y--;
                Blocks[3].Y--;
                Blocks[3].X--;
            }
            if (position == 3)
            {
                setPre();
                Blocks[0].X++;
                Blocks[0].Y--;
                Blocks[2].Y--;
                Blocks[2].X--;
                Blocks[3].Y++;
                Blocks[3].X--;
            }
            if (position == 4)
            {
                setPre();
                Blocks[0].Y--;
                Blocks[0].X--;
                Blocks[2].X--;
                Blocks[2].Y++;
                Blocks[3].Y++;
                Blocks[3].X++;
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

        public override void RotateBack()
        {
            Blocks[0].Y = preY0;
            Blocks[0].X = preX0;
            Blocks[2].Y = preY2;
            Blocks[2].X = preX2;
            Blocks[3].Y = preY3;
            Blocks[3].X = preX3;
        }

        public void setPre()
        {
            preY0 = Blocks[0].Y;
            preX0 = Blocks[0].X;
            preY2 = Blocks[2].Y;
            preX2 = Blocks[2].X;
            preY3 = Blocks[3].Y;
            preX3 = Blocks[3].X;
        }
    }
}
