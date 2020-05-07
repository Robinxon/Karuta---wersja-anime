using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Karuta___wersja_anime
{
    public partial class MainWindow : Form
    {
        private readonly List<Anime> animeList = new List<Anime>();
        public Methods methods = new Methods();
        public Worker worker = new Worker();
        public bool userInput = true;

        public MainWindow()
        {
            InitializeComponent();

            backgroundWorker.DoWork += worker.WorkerReadSongsPath;
            backgroundWorker.RunWorkerCompleted += worker.WorkerEnd;
            backgroundWorker.ProgressChanged += worker.WorkerReport;
            backgroundWorker.WorkerReportsProgress = true;
        }

        private void WybierzFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    methods.Logger("Wybrano folder", fbd.SelectedPath);
                    worker.WorkerStart(backgroundWorker, toolStripProgressBar1, toolStripStatusLabel1, fbd.SelectedPath, animeList);
                }
            }
        }

        private void WybierzPlikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    toolStripStatusLabel1.Text = ofd.FileName;

                    methods.Logger("Wybrano plik tekstowy", ofd.FileName);
                    methods.ReadTextFile(ofd.FileName, animeList, checkedListBox1);
                }
            }
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void OProgranieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Karuta - wersja anime v" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "\nAutor: Robert 'Robinxon' Dawid", "O programie", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void LogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Karuta");
            string file = Path.Combine(folder, "log.txt");

            try { System.Diagnostics.Process.Start(file); }
            catch { MessageBox.Show("Log nie istnieje", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning); }

        }

        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Anime selected = new Anime();
            selected = animeList.Find(item => item.Id == checkedListBox1.SelectedIndex + 1);
            AnimeInfoBox.Text = "";

            string[] animes = new string[selected.Songs.Count];
            int i = 0;
            foreach (Song song in selected.Songs)
            {
                animes[i] = song.Album;
                i++;
            }
            animes = animes.Distinct().ToArray();

            selected.Songs = selected.Songs.OrderBy(o => o.Track).ToList();
            foreach (string anime in animes)
            {
                methods.PrintAnimeSongInfo(anime, selected, AnimeInfoBox);
            }
        }

        private void AnimeListBox_TextChanged(object sender, EventArgs e)
        {
            methods.CheckItemsCheckList(AnimeListBox, checkedListBox1);
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }

        private void RefreshAnimeListBox_Tick(object sender, EventArgs e)
        {
            methods.PrintListToBox(checkedListBox1, AnimeListBox);
        }
    }
}
