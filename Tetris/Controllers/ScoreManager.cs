using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Tetris.Models;

namespace Tetris.Controllers
{
    public class ScoreManager
    {

        private SQLiteConnection _conn;

        public void Submit(Score s)
        {
            Connect();
            SQLiteCommand insertComm = new SQLiteCommand("INSERT INTO scores (username, score) VALUES ('" + s.Username + "', " + s.ScoreValue + ");", _conn);
            Disconnect();
        }

        public List<Score> GetAll()
        {
            Connect();
            List<Score> res = new List<Score>();
            string query = "SELECT * FROM scores ORDER BY score DESC";
            SQLiteCommand sqlcommand = new SQLiteCommand(query, _conn);
            SQLiteDataReader r = sqlcommand.ExecuteReader();
            while (r.Read())
            {
                Score s = new Score();
                s.Username = (string)r["username"];
                s.ScoreValue = (int)r["score"];
                res.Add(s);
            }
            return res;
        }

        private void Connect()
        {
            string filepath = "highscores.sqlite";
            if (!File.Exists(filepath))
            {
                SQLiteConnection.CreateFile(filepath);
                CreateSchema();
            }
            if (_conn == null)
            {
                _conn = new SQLiteConnection("Data Source="+filepath+";Version = 3;");
                _conn.Open();
            }
        }

        private void Disconnect()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn = null;
            }
        }

        private void CreateSchema()
        {
            Connect();
            SQLiteCommand createScoreTable = new SQLiteCommand("CREATE TABLE scores (username VARCHAR(10), score, INT);", _conn);
            createScoreTable.ExecuteNonQuery();
            Disconnect();
        }
    }
}
