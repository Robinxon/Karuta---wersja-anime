using System.Collections.Generic;
using System.Linq;

namespace Karuta___wersja_anime
{
    public class Game
    {
        private readonly Methods methods = new Methods();
        public List<Anime> gameAnime { get; set; } = new List<Anime>();
        public List<string> players { get; set; } = new List<string>();

        public Dictionary<string, bool> settings { get; set; } = new Dictionary<string, bool>();

        public Game() { }

        public Game(List<Anime> animeList, int[] cards, Dictionary<string, bool> settings, List<string> players)
        {
            this.players = players;
            this.settings = settings;

            int songCount = 0;

            Anime[] animes;
            animes = animeList.ToArray();
            foreach (Anime anime in animes)
            {
                if (cards.Contains(anime.Id))
                {
                    Song[] songs;
                    songs = anime.Songs.ToArray();
                    anime.Songs.Clear();

                    foreach (Song song in songs)
                    {
                        if (song.Genre == "Opening" && settings["Opening"])
                        {
                            anime.Songs.Add(song);
                            songCount++;
                        }

                        if (song.Genre == "Ending" && settings["Ending"])
                        {
                            anime.Songs.Add(song);
                            songCount++;
                        }

                        if (song.Genre == "Insert" && settings["Insert"])
                        {
                            anime.Songs.Add(song);
                            songCount++;
                        }
                    }

                    gameAnime.Add(anime);
                }
            }
            methods.Logger("Utworzono listę utworów do gry", songCount.ToString());
        }
    }
}
