﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.Models.TetriminoBag
{
    [Serializable]
    public class s_Tetrimino : Tetrimino
    {
        public s_Tetrimino()
        {
            Blocks = new List<Points>()
            {
                new Points { X = 3, Y = 1 },
                new Points { X = 4, Y = 1 },
                new Points { X = 4, Y = 0 },
                new Points { X = 5, Y = 0 }
            };
            Name = "s_Tetrimino";
        }

        private int position = 1;
        private int preY0 = 0;
        private int preX0 = 0;
        private int preY1 = 0;
        private int preX1 = 0;
        private int preY3 = 0;
        private int preX3 = 0;

        public override void Rotate()
        {
            if (position == 1)
            {
                setPre();
                Blocks[1].Y--;
                Blocks[1].X--;
                Blocks[0].Y = Blocks[0].Y - 2;
                Blocks[3].Y++;
                Blocks[3].X--;
            }
            if (position == 2)
            {
                setPre();
                Blocks[0].X = Blocks[0].X + 2;
                Blocks[1].X++;
                Blocks[1].Y--;
                Blocks[3].Y--;
                Blocks[3].X--;
            }
            if (position == 3)
            {
                setPre();
                Blocks[0].Y = Blocks[0].Y + 2;
                Blocks[1].Y++;
                Blocks[1].X++;
                Blocks[3].X++;
                Blocks[3].Y--;
            }
            if (position == 4)
            {
                setPre();
                Blocks[0].X = Blocks[0].X - 2;
                Blocks[1].X--;
                Blocks[1].Y++;
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
            Blocks[1].Y = preY1;
            Blocks[1].X = preX1;
            Blocks[3].Y = preY3;
            Blocks[3].X = preX3;
            if (position == 1)
            {
                position = 4;
            }
            else
            {
                position--;
            }
        }

        public void setPre()
        {
            preY0 = Blocks[0].Y;
            preX0 = Blocks[0].X;
            preY1 = Blocks[1].Y;
            preX1 = Blocks[1].X;
            preY3 = Blocks[3].Y;
            preX3 = Blocks[3].X;
        }
    }
}
