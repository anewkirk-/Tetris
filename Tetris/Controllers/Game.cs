using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Controllers
{
    public class Game
    {
        public GameMode Mode { get; set; }
        public bool isRunning { get; set; }
        
        //
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
