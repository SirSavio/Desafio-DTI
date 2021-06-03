using System;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Models
{
    public class Music
    {
        public int IdDisk {get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public bool IsFavorite { get; set; }

        public Music(string title, string duration, bool isFavorite)
        {
            MusicValidator validator = new MusicValidator();
            validator.Create(title, duration);
            
            this.Title = title;
            this.Duration = duration;
            this.IsFavorite = isFavorite;
        }
    }
}