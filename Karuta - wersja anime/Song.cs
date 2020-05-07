namespace Karuta___wersja_anime
{
    public class Song
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public uint Year { get; set; }
        public uint Track { get; set; }
        public string Genre { get; set; }
        public string Comment { get; set; }
        public TagLib.IPicture Cover { get; set; }
        public System.TimeSpan Duration { get; set; }
        public int Bitrate { get; set; }
        public void GetSongTags()
        {
            var tfile = TagLib.File.Create(Path);
            Title = tfile.Tag.Title;
            Artist = tfile.Tag.FirstPerformer;
            Album = tfile.Tag.Album;
            Year = tfile.Tag.Year;
            Track = tfile.Tag.Track;
            Genre = tfile.Tag.FirstGenre;
            Comment = tfile.Tag.Comment;
            Cover = tfile.Tag.Pictures[0];
            Duration = tfile.Properties.Duration;
            Bitrate = tfile.Properties.AudioBitrate;
        }
    }
}
