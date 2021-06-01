using System.Collections.Generic;

namespace Desafio_DTI_CSharp.Models
{
    public class Disk
    {
        private List<Music> musics { get; }
        private string title;
        private string release;
        private string groupName;
        
        public string Title { get; set; }
        public string Release { get; set; }
        public string GroupName { get; set; }

        public Disk(string title, string release, string groupName)
        {
            this.Title = title;
            this.Release = release;
            this.GroupName = groupName;

            this.musics = new List<Music>();
        }
        
        public Disk()
        {
            this.musics = new List<Music>();
        }


        public bool InsertMusic(Music music)
        {
            this.musics.Add(music);
            return true;
        }

        public bool RemoveMusic(Music music)
        {
            return this.musics.Contains(music);
        }

        public List<Music> GetFavoriteMusics()
        {
            List<Music> filtered = new List<Music>();
            foreach (Music music in this.musics)
            {
                if (music.IsFavorite)
                {
                    filtered.Add(music);
                }
            }
            return filtered;
        }

    }
}