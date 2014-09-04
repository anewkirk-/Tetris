using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Tetris.Controllers
{
    public class Sound
    {
        //Create new players for two player games---------------------------------
        #region Initialize MediaPlayers
        //Initialize a MediaPlayer for each sound
        MediaPlayer gameOverPlayer = new MediaPlayer();
        MediaPlayer scorePlayer = new MediaPlayer();
        MediaPlayer movePlayer = new MediaPlayer();
        MediaPlayer pausePlayer = new MediaPlayer();
        MediaPlayer rotatePlayer = new MediaPlayer();
        MediaPlayer singleLineClearPlayer = new MediaPlayer();
        MediaPlayer doubleLineClearPlayer = new MediaPlayer();
        MediaPlayer tripleLineClearPlayer = new MediaPlayer();
        MediaPlayer winPlayer = new MediaPlayer();
        MediaPlayer collissionPlayer = new MediaPlayer();
        MediaPlayer countdownPlayer = new MediaPlayer();
        MediaPlayer dominatingPlayer = new MediaPlayer();
        MediaPlayer levelUpPlayer = new MediaPlayer();
        MediaPlayer gameStartPlayer = new MediaPlayer();
        #endregion

        List<MediaPlayer> soundEffects = new List<MediaPlayer>();

        //Constructor to open file paths for sound effects
        public Sound()
        {
            #region File Paths
            //Sound effect file paths
            string dominatingPath = "Sound\\SoundEffects\\Tetris_Dominating.wav";
            string collissionPath = "Sound\\SoundEffects\\Tetris_Collission.wav";
            string countdownPath = "Sound\\SoundEffects\\Tetris_Countdown.wav";
            string doubleLineClearPath = "Sound\\SoundEffects\\Tetris_DoubleLineClear.wav";
            string gameOverPath = "Sound\\SoundEffects\\Tetris_GameOver.wav";
            string highScorePath = "Sound\\SoundEffects\\Tetris_HighScore.wav";
            string gameStartPath = "Sound\\SoundEffects\\Tetris_GameStart.wav";
            string levelUpPath = "Sound\\SoundEffects\\Tetris_LevelUp.wav";
            string movePath = "Sound\\SoundEffects\\Tetris_Move.wav";
            string pausePath = "Sound\\SoundEffects\\Tetris_Pause.wav";
            string rotatePath = "Sound\\SoundEffects\\Tetris_Rotate.wav";
            string singleLineClearPath = "Sound\\SoundEffects\\Tetris_SingleLineClear.wav";
            string tripleLineClearPath = "Sound\\SoundEffects\\Tetris_TripleLineClear.wav";
            string winPath = "Sound\\SoundEffects\\Tetris_Win.wav";
            #endregion
            #region Open File Path
            //Open sound effect files for each player
            dominatingPlayer.Open(new Uri(@dominatingPath, uriKind: UriKind.Relative));
            collissionPlayer.Open(new Uri(@collissionPath, uriKind: UriKind.Relative));
            countdownPlayer.Open(new Uri(@countdownPath, uriKind: UriKind.Relative));
            gameOverPlayer.Open(new Uri(@gameOverPath, uriKind: UriKind.Relative));
            scorePlayer.Open(new Uri(@highScorePath, uriKind: UriKind.Relative));
            gameStartPlayer.Open(new Uri(@gameStartPath, uriKind: UriKind.Relative));
            levelUpPlayer.Open(new Uri(@levelUpPath, uriKind: UriKind.Relative));
            movePlayer.Open(new Uri(@movePath, uriKind: UriKind.Relative));
            pausePlayer.Open(new Uri(@pausePath, uriKind: UriKind.Relative));
            rotatePlayer.Open(new Uri(@rotatePath, uriKind: UriKind.Relative));
            singleLineClearPlayer.Open(new Uri(@singleLineClearPath, uriKind: UriKind.Relative));
            doubleLineClearPlayer.Open(new Uri(@doubleLineClearPath, uriKind: UriKind.Relative));
            tripleLineClearPlayer.Open(new Uri(@tripleLineClearPath, uriKind: UriKind.Relative));
            winPlayer.Open(new Uri(@winPath, uriKind: UriKind.Relative));
            #endregion
        }

        //Add SFX to a list for Mute SFX
        public List<MediaPlayer> SFXList()
        {
            soundEffects.Add(gameOverPlayer);
            soundEffects.Add(scorePlayer);
            soundEffects.Add(movePlayer);
            soundEffects.Add(pausePlayer);
            soundEffects.Add(rotatePlayer);
            soundEffects.Add(singleLineClearPlayer);
            soundEffects.Add(doubleLineClearPlayer);
            soundEffects.Add(tripleLineClearPlayer);
            soundEffects.Add(winPlayer);
            soundEffects.Add(collissionPlayer);
            soundEffects.Add(countdownPlayer);
            soundEffects.Add(dominatingPlayer);
            soundEffects.Add(levelUpPlayer);
            soundEffects.Add(gameStartPlayer);

            return soundEffects;
        }
        
        #region Methods to play each sound effect
        public void PlayWinSFX()
        {
            winPlayer.Stop();
            winPlayer.Play();

        }

        public void PlayLevelUpSFX()
        {
            levelUpPlayer.Stop();
            levelUpPlayer.Play();
        }

        public void PlayHighScoreSFX()
        {
            scorePlayer.Stop();
            scorePlayer.Play();
        }

        public void PlayGameStartSFX()
        {
            gameStartPlayer.Stop();
            gameStartPlayer.Play();
        }

        public void PlayGameOverSFX()
        {
            gameOverPlayer.Stop();
            gameOverPlayer.Play();
        }

        public void PlayDominatingSFX()
        {
            dominatingPlayer.Stop();
            dominatingPlayer.Play();
        }

        public void PlayTripleLineClearSFX()
        {
            tripleLineClearPlayer.Stop();
            tripleLineClearPlayer.Play();
        }

        public void PlaySingleLineClearSFX()
        {
            singleLineClearPlayer.Stop();
            singleLineClearPlayer.Play();
        }

        public void PlayDoubleLineClearSFX()
        {
            doubleLineClearPlayer.Stop();
            doubleLineClearPlayer.Play();
        }

        public void PlayPauseSFX()
        {
            pausePlayer.Stop();
            pausePlayer.Play();
        }

        public void PlayCollisionSFX()
        {
            collissionPlayer.Stop();
            collissionPlayer.Play();
        }

        public void PlayRotateSFX()
        {
            rotatePlayer.Stop();
            rotatePlayer.Play();
        }

        public void PlayMoveSFX()
        {
            movePlayer.Stop();
            movePlayer.Play();
        }

        public void PlayCountdownSFX()
        {
            countdownPlayer.Stop();
            countdownPlayer.Play();
        }
        #endregion
    }
}
