using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Karuta___wersja_anime
{
    public class Methods
    {
        public bool userInput = true;

        public void Logger(string message, string argument)
        {
            string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Karuta");
            string file = Path.Combine(folder, "log.txt");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine("Karuta - wersja anime | LOG");
                }
            }

            using (StreamWriter sw = File.AppendText(file))
            {
                sw.WriteLine(DateTime.Now.ToString() + " - " + message + " " + argument);
            }
        }

        public void ReadTextFile(string path, List<Anime> animeList, ListBox listBox)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                string line;
                int count = 1;
                while ((line = file.ReadLine()) != null)
                {
                    Anime anime = new Anime();
                    string[] splitted = line.Split('|');
                    anime.Id = count++;
                    anime.Name = splitted[0];
                    foreach (string item in splitted.Skip(1))
                    {
                        anime.AddFolder(item);
                    }
                    animeList.Add(anime);
                    listBox.Items.Add(anime.Id + " " + anime.Name + " " + anime.Folders.Count.ToString());
                }
                file.Close();
            }
            catch (Exception e)
            {
                Logger("Błąd podczas odczytu pliku tekstowego", e.ToString());
            }
            finally
            {
                Logger("Pomyślnie odczytano plik tekstowy", null);
            }
        }

        public void PrintAnimeSongInfo(string anime, Anime animeCheck, TextBox AnimeInfoBox)
        {
            AnimeInfoBox.Text += anime + Environment.NewLine;

            foreach (Song song in animeCheck.Songs)
            {
                if (anime == song.Album && song.Genre == "Opening")
                {
                    AnimeInfoBox.Text += "\u2022" + song.Genre + " " + song.Track + " | " + song.Artist + " - " + song.Title + Environment.NewLine;
                }
            }

            foreach (Song song in animeCheck.Songs)
            {
                if (anime == song.Album && song.Genre == "Ending")
                {
                    AnimeInfoBox.Text += "\u2022" + song.Genre + " " + song.Track + " | " + song.Artist + " - " + song.Title + Environment.NewLine;
                }
            }

            foreach (Song song in animeCheck.Songs)
            {
                if (anime == song.Album && song.Genre == "Insert")
                {
                    AnimeInfoBox.Text += "\u2022" + song.Genre + " " + song.Track + " | " + song.Artist + " - " + song.Title + Environment.NewLine;
                }
            }

            AnimeInfoBox.Text += Environment.NewLine;
        }

        public void CheckItemsCheckList(TextBox AnimeListBox, CheckedListBox checkedListBox1)
        {
            if (userInput)
            {
                string[] animeIds = AnimeListBox.Text.Replace(" ", "").Split(',').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                int[] ints = Array.ConvertAll(animeIds, s => int.Parse(s));

                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (ints.Contains(i + 1))
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                    else
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        public void PrintListToBox(CheckedListBox checkedListBox1, TextBox AnimeListBox)
        {
            if(!AnimeListBox.Focused)
            {
                string[] checkedItems = checkedListBox1.CheckedItems.OfType<string>().ToArray();
                for (int k = 0; k < checkedItems.Length; k++)
                {
                    checkedItems[k] = (checkedListBox1.Items.IndexOf(checkedItems[k]) + 1).ToString();
                }

                string animeListString = "";
                foreach (string id in checkedItems)
                {
                    animeListString += id + ",";
                }

                userInput = false;
                AnimeListBox.Text = animeListString;
                AnimeListBox.Select(AnimeListBox.Text.Length, 0);
                userInput = true;
            }
        }
    }
}
