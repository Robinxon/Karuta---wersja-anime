using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Karuta___wersja_anime
{
    public class Worker
    {
        public BackgroundWorker backgroundWorker;
        public ToolStripProgressBar progressBar;
        public ToolStripLabel label;
        public string path;
        public List<Anime> animeList;
        public Methods methods = new Methods();
        public TextBox AnimeListBox;
        public CheckedListBox checkedListBox1;
        public TextBox AnimeInfoBox;

        public void WorkerStart(BackgroundWorker backgroundWorker, ToolStripProgressBar progressBar, ToolStripLabel label, string path, List<Anime> animeList, TextBox AnimeListBox, CheckedListBox checkedListBox1, TextBox AnimeInfoBox)
        {
            methods.Logger("Inicjacja workera", null);
            this.backgroundWorker = backgroundWorker;
            this.progressBar = progressBar;
            this.label = label;
            this.path = path;
            this.animeList = animeList;
            this.AnimeListBox = AnimeListBox;
            this.checkedListBox1 = checkedListBox1;
            this.AnimeInfoBox = AnimeInfoBox;

            this.label.Text = "Zajęty...";
            string[] files = Directory.GetFiles(this.path, "*.mp3", SearchOption.AllDirectories);
            methods.Logger("Obliczono liczbę plików mp3 w folderze", files.Length.ToString());
            this.progressBar.Maximum = files.Length;
            this.progressBar.Value = 0;
            this.backgroundWorker.RunWorkerAsync();
        }

        public void WorkerReadSongsPath(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            methods.Logger("Worker zaczął pracę", null);
            try
            {
                int count = 1;
                foreach (Anime anime in animeList)
                {
                    foreach (string folders in anime.Folders)
                    {
                        var foldersFound = Directory.GetDirectories(path, folders, SearchOption.AllDirectories);
                        foreach (string folder in foldersFound)
                        {
                            string[] files = Directory.GetFiles(folder, "*.mp3");
                            foreach (string file in files)
                            {
                                anime.AddSongPath(file);
                                backgroundWorker.ReportProgress(count++);
                            }
                        }
                    }
                }
            }
            catch (Exception err)
            {
                methods.Logger("Błąd podczas pracy workera", err.ToString());
            }
        }

        public void WorkerEnd(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            progressBar.Value = 0;
            AnimeListBox.Enabled = true;
            checkedListBox1.Enabled = true;
            AnimeInfoBox.Enabled = true;
            methods.Logger("Worker zakończył pracę", label.Text);
            label.Text += " Koniec";
        }

        public void WorkerReport(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            try
            {
                progressBar.Value = e.ProgressPercentage;
            }
            catch { }
            label.Text = "Wczytano: " + e.ProgressPercentage;
        }
    }
}
