using System;

namespace Desafio_DTI_CSharp.Models
{
    public class Music
    {
        private string title;
        private string duration;
        private bool isFavorite;
        
        public string Title { get; set; }
        public string Duration { get; set; }
        public bool IsFavorite { get; set; }

        public Music(string title, string duration, bool isFavorite)
        {
            this.Title = title;
            this.Duration = duration;
            this.isFavorite = isFavorite;
        }
        
        
        
        
        public void Print(Music music)
        {
            Console.WriteLine("Titulo: " + music.Title);
            Console.WriteLine("Duração: " + music.Duration);
            Console.WriteLine("É favorita: " + music.IsFavorite);
        }
    }
}