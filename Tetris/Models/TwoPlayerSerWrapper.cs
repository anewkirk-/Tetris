﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Controllers;

namespace Tetris.Models
{
    [Serializable]
    public class TwoPlayerSerWrapper
    {
        public Game PlayerOneGame { get; set; }
        public Game PlayerTwoGame { get; set; }
        public int TimerInterval { get; set; }
    }
}
