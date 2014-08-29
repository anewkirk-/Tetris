using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models.TetriminoBag;

namespace Tetris.Models
{
    [Serializable]
    public class TetrisBoard : List<Tetrimino> { }
}
