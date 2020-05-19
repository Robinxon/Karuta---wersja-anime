using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Karuta___wersja_anime
{
    public partial class GameWindow : Form
    {
        //inicjacja obiektów i zmiennych globalnych
        public int[] points;
        public Game game = new Game();
        public Random rand = new Random();
        public int randomAnimeId;
        public int countdown;
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Anime animePlaying;
        private Song songPlaying;

        public GameWindow(Game game)
        {
            InitializeComponent();

            //inicjacja zmiennych
            this.game = game;
            points = new int[game.players.Count];

            //wpisanie nazw graczy do słownika i textboxów
            for (int i = 0; i < game.players.Count; i++)
            {
                points[i] = 0;
                SetPlayerNameAndPoints(i);
            }

            //rozpoczęcie gry
            RandomSong();

        }

        public void RandomSong()
        {
            labelLeft.Text = "Pozostało: " + game.gameAnime.Count.ToString();

            randomAnimeId = rand.Next(0, game.gameAnime.Count);
            animePlaying = game.gameAnime.ElementAt(randomAnimeId);
            songPlaying = animePlaying.Songs.ElementAt(rand.Next(0, animePlaying.Songs.Count));

            outputDevice = new WaveOutEvent();
            audioFile = new AudioFileReader(songPlaying.Path);
            outputDevice.Init(audioFile);

            if (!game.settings["FromStart"])
            {
                double randomStart = rand.Next(0, (int)audioFile.TotalTime.TotalSeconds - 30);
                double frameNumber = Math.Floor(randomStart * outputDevice.OutputWaveFormat.SampleRate);
                long bytePos = (long)frameNumber * outputDevice.OutputWaveFormat.Channels * outputDevice.OutputWaveFormat.BitsPerSample / 8;
                audioFile.Position = bytePos;
            }
        }

        public System.Drawing.Image ShowCover(Song song)
        {
            MemoryStream ms = new MemoryStream(song.Cover.Data.Data);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        public void SetPlayerNameAndPoints(int i)
        {
            TextBox player = Controls.Find("textBoxPlayer" + (i + 1).ToString(), true)[0] as TextBox;
            player.Text = game.players.ElementAt(i) + " - " + points[i].ToString();
        }

        #region PlayerPointsUp
        public void PlayerPointsUp(int i)
        {
            points[i]++;
            SetPlayerNameAndPoints(i);
        }

        private void ButtonPlayer1Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(0);
        }

        private void ButtonPlayer2Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(1);
        }

        private void ButtonPlayer3Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(2);
        }

        private void ButtonPlayer4Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(3);
        }

        private void ButtonPlayer5Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(4);
        }

        private void ButtonPlayer6Plus_Click(object sender, EventArgs e)
        {
            PlayerPointsUp(5);
        }
        #endregion
        #region PlayerPointsDown
        public void PlayerPointsDown(int i)
        {
            points[i]--;
            SetPlayerNameAndPoints(i);
        }

        private void ButtonPlayer1Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(0);
        }

        private void ButtonPlayer2Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(1);
        }

        private void ButtonPlayer3Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(2);
        }

        private void ButtonPlayer4Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(3);
        }

        private void ButtonPlayer5Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(4);
        }

        private void ButtonPlayer6Minus_Click(object sender, EventArgs e)
        {
            PlayerPointsDown(5);
        }
        #endregion

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            countdown = 2;
            pictureBoxCover.Image = pictureBoxCover.Image = Properties.Resources.countdown_3;
            timerCountdown.Enabled = true;
        }

        private void ButtonPause_Click(object sender, EventArgs e)
        {
            pictureBoxCover.Image = Properties.Resources.pause;
            outputDevice.Pause();
            buttonPause.Enabled = false;
            buttonPlay.Enabled = true;
            buttonStop.Enabled = true;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            outputDevice?.Stop();
            buttonPlay.Enabled = false;
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            buttonNext.Enabled = true;

            timerTick.Enabled = false;
            labelPosition.Text = "";

            pictureBoxCover.Image = ShowCover(songPlaying);
            labelAnime.Text = songPlaying.Album;
            labelSong.Text = songPlaying.Artist + " - " + songPlaying.Title;
            labelGenre.Text = songPlaying.Genre + " " + songPlaying.Track;
            labelYear.Text = songPlaying.Year + " " + songPlaying.Comment;
            FontResize();

            game.gameAnime.RemoveAt(randomAnimeId);
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = true;
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            buttonNext.Enabled = false;

            labelAnime.Text = "";
            labelSong.Text = "";
            labelGenre.Text = "";
            labelYear.Text = "";
            pictureBoxCover.Image = null;

            if (game.gameAnime.Count >= 1)
            {
                RandomSong();
            }
            else
            {
                GameEnd();
            }
        }

        public void GameEnd()
        {
            labelAnime.Text = "Koniec gry!";
            buttonPlay.Enabled = false;
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            buttonNext.Enabled = false;
        }

        private void TrackBarVolume_Scroll(object sender, EventArgs e)
        {
            audioFile.Volume = trackBarVolume.Value / 100f;
        }

        private void TimerTick_Tick(object sender, EventArgs e)
        {
            try
            {
                double ms = audioFile.Position * 1000 / outputDevice.OutputWaveFormat.BitsPerSample / outputDevice.OutputWaveFormat.Channels * 8 / outputDevice.OutputWaveFormat.SampleRate;
                TimeSpan t = TimeSpan.FromMilliseconds(ms);
                labelPosition.Text = string.Format("{0:D1}:{1:D2}", t.Minutes, t.Seconds);
                labelPosition.Text += " / " + audioFile.TotalTime.ToString("mm\\:ss");
            }
            catch { labelPosition.Text = ""; }
        }

        private void TimerCountdown_Tick(object sender, EventArgs e)
        {
            switch (countdown)
            {
                case 2:
                    pictureBoxCover.Image = pictureBoxCover.Image = Properties.Resources.countdown_2;
                    break;
                case 1:
                    pictureBoxCover.Image = pictureBoxCover.Image = Properties.Resources.countdown_1;
                    break;
            }
            if (countdown > 0)
            {
                countdown--;
            }
            else
            {
                timerCountdown.Enabled = false;

                pictureBoxCover.Image = pictureBoxCover.Image = Properties.Resources.play;
                outputDevice.Play();
                buttonPlay.Enabled = false;
                buttonPause.Enabled = true;
                buttonStop.Enabled = true;

                timerTick.Enabled = true;
            }
        }

        private void GameWindow_Resize(object sender, EventArgs e)
        {
            //pozycjonowanie 1040; 550
            buttonPlayer1Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer1Minus.Top = (int)(ClientSize.Height / 45.83333333333333);

            buttonPlayer2Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer2Minus.Top = (int)(ClientSize.Height / 11.22448979591837);

            buttonPlayer3Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer3Minus.Top = (int)(ClientSize.Height / 6.395348837209302);

            buttonPlayer4Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer4Minus.Top = (int)(ClientSize.Height / 4.471544715447154);

            buttonPlayer5Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer5Minus.Top = (int)(ClientSize.Height / 3.4375);

            buttonPlayer6Minus.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlayer6Minus.Top = (int)(ClientSize.Height / 2.791878172588832);

            buttonPlayer1Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer1Plus.Top = (int)(ClientSize.Height / 45.83333333333333);

            buttonPlayer2Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer2Plus.Top = (int)(ClientSize.Height / 11.22448979591837);

            buttonPlayer3Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer3Plus.Top = (int)(ClientSize.Height / 6.395348837209302);

            buttonPlayer4Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer4Plus.Top = (int)(ClientSize.Height / 4.471544715447154);

            buttonPlayer5Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer5Plus.Top = (int)(ClientSize.Height / 3.4375);

            buttonPlayer6Plus.Left = (int)(ClientSize.Width / 4.176706827309237);
            buttonPlayer6Plus.Top = (int)(ClientSize.Height / 2.791878172588832);

            buttonPlayer1Minus.Width = buttonPlayer2Minus.Width = buttonPlayer3Minus.Width = buttonPlayer4Minus.Width = buttonPlayer5Minus.Width = buttonPlayer6Minus.Width =
                buttonPlayer1Plus.Width = buttonPlayer2Plus.Width = buttonPlayer3Plus.Width = buttonPlayer4Plus.Width = buttonPlayer5Plus.Width = buttonPlayer6Plus.Width =
                (int)(ClientSize.Width / 34.66666666666666);
            buttonPlayer1Minus.Height = buttonPlayer2Minus.Height = buttonPlayer3Minus.Height = buttonPlayer4Minus.Height = buttonPlayer5Minus.Height = buttonPlayer6Minus.Height =
                buttonPlayer1Plus.Height = buttonPlayer2Plus.Height = buttonPlayer3Plus.Height = buttonPlayer4Plus.Height = buttonPlayer5Plus.Height = buttonPlayer6Plus.Height =
                (int)(ClientSize.Height / 18.33333333333333);

            textBoxPlayer1.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer1.Top = (int)(ClientSize.Height / 45.83333333333333);

            textBoxPlayer2.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer2.Top = (int)(ClientSize.Height / 11.22448979591837);

            textBoxPlayer3.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer3.Top = (int)(ClientSize.Height / 6.395348837209302);

            textBoxPlayer4.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer4.Top = (int)(ClientSize.Height / 4.471544715447154);

            textBoxPlayer5.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer5.Top = (int)(ClientSize.Height / 3.4375);

            textBoxPlayer6.Left = (int)(ClientSize.Width / 24.18604651162791);
            textBoxPlayer6.Top = (int)(ClientSize.Height / 2.791878172588832);

            textBoxPlayer1.Width = textBoxPlayer2.Width = textBoxPlayer3.Width = textBoxPlayer4.Width = textBoxPlayer5.Width = textBoxPlayer6.Width =
                (int)(ClientSize.Width / 5.2);

            textBoxPlayer1.Height = textBoxPlayer2.Height = textBoxPlayer3.Height = textBoxPlayer4.Height = textBoxPlayer5.Height = textBoxPlayer6.Height =
                (int)(ClientSize.Height / 17.74193548387097);

            labelLeft.Left = (int)(ClientSize.Width / 148.5714285714286);
            labelLeft.Top = (int)(ClientSize.Height / 2.380952380952381);
            labelLeft.Width = (int)(ClientSize.Width / 3.823529411764706);
            labelLeft.Height = (int)(ClientSize.Height / 23.91304347826087);

            buttonPlay.Left = buttonStop.Left = (int)(ClientSize.Width / 148.5714285714286);
            buttonPlay.Top = buttonPause.Top = (int)(ClientSize.Height / 2.140077821011673);
            buttonPause.Left = buttonNext.Left = (int)(ClientSize.Width / 6.753246753246753);
            buttonStop.Top = buttonNext.Top = (int)(ClientSize.Height / 1.757188498402556);

            buttonPlay.Width = buttonPause.Width = buttonStop.Width = buttonNext.Width = (int)(ClientSize.Width / 8.32);
            buttonPlay.Height = buttonPause.Height = buttonStop.Height = buttonNext.Height = (int)(ClientSize.Height / 11);

            trackBarVolume.Left = (int)(ClientSize.Width / 148.5714285714286);
            trackBarVolume.Top = (int)(ClientSize.Height / 1.490514905149051);
            trackBarVolume.Width = (int)(ClientSize.Width / 3.823529411764706);
            trackBarVolume.Height = (int)(ClientSize.Height / 12.2222222222222);

            labelPosition.Left = (int)(ClientSize.Width / 260);
            labelPosition.Top = (int)(ClientSize.Height / 1.371571072319202);
            labelPosition.Width = (int)(ClientSize.Width / 3.78181818181818);
            labelPosition.Height = (int)(ClientSize.Height / 18.3333333333333);

            labelAnime.Left = labelSong.Left = (int)(ClientSize.Width / 3.649122807017544);
            labelAnime.Top = (int)(ClientSize.Height / 61.11111111111111);
            labelSong.Top = (int)(ClientSize.Height / 7.746478873239437);
            labelAnime.Width = labelSong.Width = (int)(ClientSize.Width / 1.430536451169188);
            labelAnime.Height = (int)(ClientSize.Height / 8.8709677419635484);
            labelSong.Height = (int)(ClientSize.Height / 7.236842105263158);

            pictureBoxCover.Left = (int)(ClientSize.Width / 2.212765957446809);
            pictureBoxCover.Top = (int)(ClientSize.Height / 3.666666666666666);
            pictureBoxCover.Width = (int)(ClientSize.Width / 2.979942693409742);
            pictureBoxCover.Height = (int)(ClientSize.Height / 1.575931232091691);

            labelGenre.Left = labelYear.Left = (int)(ClientSize.Width / 1.2590799031477);
            labelGenre.Top = (int)(ClientSize.Height / 3.666666666666666);
            labelYear.Top = (int)(ClientSize.Height / 3.055555555555555);
            labelGenre.Width = labelYear.Width = (int)(ClientSize.Width / 5.591397849462366);
            labelGenre.Height = labelYear.Height = (int)(ClientSize.Height / 18.33333333333333);

            //wielkość czcionek
            FontResize();
        }

        public void FontResize()
        {
            List<Label> labels = new List<Label>
            {
                labelAnime,
                labelGenre,
                labelPosition,
                labelLeft,
                labelSong,
                labelYear
            };

            foreach (Label aLabel in labels)
            {
                aLabel.Font = new Font(aLabel.Font.FontFamily, 72, aLabel.Font.Style);
                while (aLabel.Width < TextRenderer.MeasureText(aLabel.Text, new Font(aLabel.Font.FontFamily, aLabel.Font.Size, aLabel.Font.Style)).Width)
                {
                    aLabel.Font = new Font(aLabel.Font.FontFamily, aLabel.Font.Size - 0.5f, aLabel.Font.Style);
                }
                while (aLabel.Height < TextRenderer.MeasureText(aLabel.Text, new Font(aLabel.Font.FontFamily, aLabel.Font.Size, aLabel.Font.Style)).Height)
                {
                    aLabel.Font = new Font(aLabel.Font.FontFamily, aLabel.Font.Size - 0.5f, aLabel.Font.Style);
                }
            }
        }
    }
}
