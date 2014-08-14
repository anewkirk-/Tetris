﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris.Models;
using Tetris.Models.TetriminoBag;

namespace Tetris.Controllers
{
    public class Game
    {
        public GameMode Mode { get; set; }
        public TetrisBoard GameBoard { get; set; }
        private Tetrimino CurrentTetrimino { get; set; }
        
        //This method contains all the logic that happens in one discrete unit of time during a Tetris game
        public void Tick()
        {
            throw new NotImplementedException();
        }

        //Add a row of Tetrimino's with an empty space in the middle when a "Tetris" has occured on the other player's screen
        public void AddRowSansOne()
        {
            throw new NotImplementedException();
        }

        public void StartMoveLeft()
        {
            throw new NotImplementedException();
        }

        public void StartMoveRight()
        {
            throw new NotImplementedException();
        }

        public void StopMoveLeft()
        {
            throw new NotImplementedException();
        }

        public void StopMoveRight()
        {
            throw new NotImplementedException();
        }

        public void StartHardDrop()
        {
            throw new NotImplementedException();
        }

        public void StopHardDrop()
        {
            throw new NotImplementedException();
        }

        public void RotateCurrent()
        {
            throw new NotImplementedException();
        }
    }
}
