using System.Collections.Generic;
using System;

namespace Karuta___wersja_anime
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Folders { get; set; } = new List<string>();
        public List<Song> Songs { get; set; } = new List<Song>();

        public void AddFolder(string folder)
        {
            List<string> temp = Folders;
            Folders.Add(folder);
            Folders = temp;
        }
        public void AddSongPath(string path)
        {
            Song temp = new Song
            {
                Path = path
            };
            temp.GetSongTags();
            Songs.Add(temp);
        }
        public void AddSong(Song song)
        {
            List<Song> temp = Songs;
            Songs.Add(song);
            Songs = temp;
        }
    }
}
