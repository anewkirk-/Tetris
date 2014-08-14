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
        private int _scoreValue;

        public Score() { }

        public Score(string username, int scoreValue)
        {
            this.Username = username;
            this.ScoreValue = ScoreValue;
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public int ScoreValue
        {
            get { return _scoreValue; }
            set { _scoreValue = value; }
        }
    }
}
