using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Models
{
    public class Score
    {
        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private int _scoreValue;

        public int ScoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }
    }
}
