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
        public bool LeftKey { get; set; }
        public bool RightKey { get; set; }
        public bool DownKey { get; set; }
        public bool LeftRotateKey { get; set; }
        public bool RightRotateKey { get; set; }

        
        public void Play()
        {

        }

        public bool isCollision()
        {
            return false;
        }
    
        //Tetrimino moves down one per tick
        //semiphore here - threads lock the resource until they are finished with them
        public void Drop()
        {
            
        }

        //Add a row of Tetrimino's with an empty space in the middle when a "Tetris" has occured
        public void AddRowSansOne()
        {

        }
    }
}
