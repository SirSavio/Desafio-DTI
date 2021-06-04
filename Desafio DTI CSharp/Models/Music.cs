using System;
using Desafio_DTI_CSharp.Validators;

namespace Desafio_DTI_CSharp.Models
{
    public class Music
    {
        public int IdDisk {get; set; }
        public string Title { get; }
        public string Duration { get; }
        public bool IsFavorite { get; }

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