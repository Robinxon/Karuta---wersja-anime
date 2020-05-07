using System.Collections.Generic;

namespace Karuta___wersja_anime
{
    class Game
    {
        public List<Anime> animeList;
        public int[] cards;

        public void Start(List<Anime> animeList, int[] cards)
        {
            this.animeList = animeList;
            this.cards = cards;
        }
    }
}
