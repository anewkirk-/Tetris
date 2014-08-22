using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.Models.TetriminoBag
{
    public class z_Tetrimino : Tetrimino
    {
        public z_Tetrimino()
        {
            color = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Blocks = new List<Points>()
            {
                new Points { X = 0, Y = 0 },
                new Points { X = 0, Y = 1 },
                new Points { X = 1, Y = 1 },
                new Points { X = 1, Y = 2 }
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
                Blocks[2].Y--;
                Blocks[2].X--;
                Blocks[3].Y = Blocks[3].Y - 2;
            }
            if (position == 2)
            {
                setPre();
                Blocks[0].Y++;
                Blocks[0].X++;
                Blocks[2].X--;
                Blocks[2].Y++;
                Blocks[3].X = Blocks[3].X - 2;
            }
            if (position == 3)
            {
                setPre();
                Blocks[0].X++;
                Blocks[0].Y--;
                Blocks[2].Y++;
                Blocks[2].X++;
                Blocks[3].Y = Blocks[3].Y + 2;
            }
            if (position == 4)
            {
                setPre();
                Blocks[0].Y--;
                Blocks[0].X--;
                Blocks[2].Y--;
                Blocks[2].X++;
                Blocks[3].X = Blocks[3].X + 2;
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