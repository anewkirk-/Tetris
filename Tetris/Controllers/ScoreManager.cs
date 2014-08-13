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
    class ScoreManager
    {

        private static SQLiteConnection _conn;

        public static void Submit(Score s)
        {
            Connect();
            SQLiteCommand insertComm = new SQLiteCommand("INSERT INTO scores (username, score) VALUES ('" + s.Username + "', " + s.ScoreValue + ");", _conn);
            Disconnect();
        }

        public static List<Score> GetAll()
        {
            throw new NotImplementedException();
        }

        private static void Connect()
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

        private static void Disconnect()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn = null;
            }
        }

        private static void CreateSchema()
        {
            Connect();
            SQLiteCommand createScoreTable = new SQLiteCommand("CREATE TABLE scores (username VARCHAR(10), score, INT);", _conn);
            createScoreTable.ExecuteNonQuery();
            Disconnect();
        }
    }
}
